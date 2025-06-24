using iTasks.Controlador;
using iTasks.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace iTasks.Controlador
{
    class TarefaControlador
    {
        private int idGestor;

        public ITaskContext Context { get; set; }
        public TarefaControlador()
        {
            Context = new ITaskContext();
        }

        // VAI BUSCAR TAREFA À BASE DE DADOS SENGUNDO O ID, RETORNA NULL SE NÃO ENCONTRAR
        public Tarefa CarregarTarefa(int Id)
        {
            return Context.Tarefas.FirstOrDefault(t => t.Id == Id);
            
        }

        public void AtualizarTarefa(Tarefa tarefa)
        {
            // Carrega a tarefa original da base de dados pelo Id
            var tarefaOriginal = Context.Tarefas.FirstOrDefault(t => t.Id == tarefa.Id);

            if (tarefaOriginal != null)
            {
                // Atualiza os campos que podem ter sido alterados
                tarefaOriginal.Descricao = tarefa.Descricao;
                tarefaOriginal.IdTipoTarefa = tarefa.IdTipoTarefa;
                tarefaOriginal.IdProgramador = tarefa.IdProgramador;
                tarefaOriginal.OrdemExecucao = tarefa.OrdemExecucao;
                tarefaOriginal.StoryPoints = tarefa.StoryPoints;
                tarefaOriginal.DataPrevistaInicio = tarefa.DataPrevistaInicio;
                tarefaOriginal.DataPrevistaFim = tarefa.DataPrevistaFim;


                // Salva as alterações no banco
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("Tarefa não encontrada para atualização.");
            }
        }

        //-----------------------METODOS QUE VAO SER CHAMADOS NO FORM DETALHES DE TAREFA--------------------------------

        // METODO CRIAR/EDITAR TAREFA KANBAN
        public void GuardaTarefa(Tarefa tarefa)
        {
            try
            {
                var tarefaExistente = Context.Tarefas.Find(tarefa.Id);

                if (tarefaExistente != null) // SE A TAREFA EXISTIR
                {
                    // Atualizar campos
                    tarefaExistente.Descricao = tarefa.Descricao;
                    tarefaExistente.IdTipoTarefa = tarefa.IdTipoTarefa;
                    tarefaExistente.IdProgramador = tarefa.IdProgramador;
                    tarefaExistente.OrdemExecucao = tarefa.OrdemExecucao;
                    tarefaExistente.StoryPoints = tarefa.StoryPoints;
                    tarefaExistente.DataPrevistaInicio = tarefa.DataPrevistaInicio;
                    tarefaExistente.DataPrevistaFim = tarefa.DataPrevistaFim;

                    Context.SaveChanges();
                    MessageBox.Show("Tarefa atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // SE A TAREFA NÃO EXISTIR, CRIA NOVA
                {
                    Context.Tarefas.Add(tarefa);
                    Context.SaveChanges();
                    MessageBox.Show("Nova tarefa criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar a tarefa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    Console.WriteLine($"Inner Exception Stack Trace: {ex.InnerException.StackTrace}");
                }
                // Podes também re-lançar a exceção se for necessário
                throw;
            }
        }

        // METODO APAGAR TAREFA KANBAN
        public void ApagarTarefa(int idTarefa, int idGestor)
        {
            var tarefaApagar = Context.Tarefas.FirstOrDefault(t => t.Id == idTarefa && t.IdGestor == idGestor);

            if (tarefaApagar != null)
            {
                Context.Tarefas.Remove(tarefaApagar);
                Context.SaveChanges();
            }
         
        }

        // ATUALIZAR TAREFA KANBAN 
        public void AtualizarEstadoTarefa(int idTarefa, int idUtilizadorAtual)
        {
            try
            {
                // carregar tarefa pelo id
                Tarefa tarefaEncontrada = Context.Tarefas.FirstOrDefault(t => t.Id == idTarefa);

                if (tarefaEncontrada != null)
                {
                    // valida se o utilizador pode alterar (exemplo para gestor)
                    if (UtilizadorumGestor(idUtilizadorAtual) && tarefaEncontrada.IdGestor != idUtilizadorAtual)
                    {
                        throw new UnauthorizedAccessException("Não pode alterar tarefas de outros gestores.");
                    }

                    // atualizar estado
                    if (tarefaEncontrada.estadoatual == EstadoAtual.ToDo)
                    {
                        tarefaEncontrada.estadoatual = EstadoAtual.Doing;
                        tarefaEncontrada.DataRealInicio = DateTime.Now;
                    }
                    else if (tarefaEncontrada.estadoatual == EstadoAtual.Doing)
                    {
                        tarefaEncontrada.estadoatual = EstadoAtual.Done;
                        tarefaEncontrada.DataRealFim = DateTime.Now;
                    }

                    Context.SaveChanges();
                }
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show(uaEx.Message, "Tarefa pertence a outra equipa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar ou atualizar a tarefa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UtilizadorumGestor(int idUtilizador)
        {
            // lógica para verificar se o utilizador é gestor, por exemplo:
            var utilizador = Context.Utilizadores.Find(idUtilizador);
            return utilizador is Gestor;
        }


        // REVERTER ESTADO TAREFA KANBAN
        public void ReverterEstadoTarefa(int Id)
        {
            try
            {
                // carregar tarefa pelo id
                Tarefa tarefaEncontrada = Context.Tarefas
                                                 .Where(t => t.Id == Id)
                                                 .FirstOrDefault();

                if (tarefaEncontrada != null)
                {

                    if (tarefaEncontrada.estadoatual == EstadoAtual.Doing)
                    {
                        tarefaEncontrada.estadoatual = EstadoAtual.ToDo;

                        // atualizar a data para o min, de maneira a dar 'reset' à mesma
                        tarefaEncontrada.DataRealInicio = DateTime.Now;
                        
                    }

                    Context.SaveChanges();
                }
                else
                {
                    MessageBox.Show($"Tarefa com ID {Id} não encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar ou atualizar a tarefa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // MÉTODOS PARA IMPLEMEMTAÇÃO DE REGRAS
        public int TarefasEmDoing(int idProg)
        {
            return Context.Tarefas
                .Where(t => t.IdProgramador == idProg && t.estadoatual == EstadoAtual.Doing)
                .Count();
        }

        public bool VerificarTarefaPrioritariaToDo(Tarefa tarefaSelecionada, int idProg)
        {
            // lista de tarefas por programador e estado
            var tarefasToDo = Context.Tarefas
                .Where(t => t.IdProgramador == idProg && t.estadoatual == EstadoAtual.ToDo)
                .OrderBy(t => t.OrdemExecucao)
                .ToList();

            // Se não houver tarefas a fazer, não há ordem a verificar
            if (tarefasToDo.Count == 0)
            {
                return true;
            }
                
            var tarefaPrioritaria = tarefasToDo.First(); //retorna a primeira da lista que foi ordenada por ordem de execução

            return tarefaSelecionada.Id == tarefaPrioritaria.Id; // true ou false
        }

        public bool VerificarTarefaPrioritariaDoing(Tarefa tarefaSelecionada, int idProg)
        {
            // lista de tarefas por programador e estado
            var tarefasDoing = Context.Tarefas
                .Where(t => t.IdProgramador == idProg && t.estadoatual == EstadoAtual.Doing)
                .OrderBy(t => t.OrdemExecucao)
                .ToList();

            var tarefaPrioritaria = tarefasDoing.First(); // first retorna a primeira da lista que foi ordenada por ordem de execução

            return tarefaSelecionada.Id == tarefaPrioritaria.Id; // true ou false
        }

        public bool VerificarOrdemTarefas(int ordem, int idProgramador, int idTarefaAtual = 0)
        {
            return Context.Tarefas.Any(t =>
                t.IdProgramador == idProgramador &&
                t.OrdemExecucao == ordem &&
                t.Id != idTarefaAtual);
        }


        // LISTAS PARA APRESENTAÇÃO NA VIEW
        public List<TipoTarefa> ListaTiposTarefa()
        {
            return Context.TipoTarefas
               .OrderBy(p => p.Nome) // ordena por nome
               .ToList();
        }

        public List<Tarefa> ListaToDo()
        {
            return Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.ToDo)
               .OrderBy(p => p.Id) // aqui ordena por ID
               .ToList();
        }

        public List<Tarefa> ListaDoing()
        {
            return Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.Doing)
               .OrderBy(p => p.Id)
               .ToList();
        }

        public List<Tarefa> ListaDone()
        {
            return Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.Done)
               .OrderBy(p => p.Id)
               .ToList();
        }

        public List<Programador> ListaProgramadores()
        {
            return Context.Programadores
               .Where(p => p.IdGestor == idGestor) //retornar os programadores pertencentes a um gestor em especifico
               .OrderBy(p => p.Nome)
               .ToList();
        }
        public List<Programador> ListaProgramadoresPorGestor(int idGestor)
        {
            return Context.Programadores
                .Where(p => p.IdGestor == idGestor)
                .OrderBy(p => p.Nome)
                .ToList();
        }



        //METODO PARA VER A PREVISÃO DO TEMPO DAS TAREFAS
        //TIMESPAN DEVOLVE O TEMPO ESTIMADO TOTAL COM O ID DO GESTOR EM QUESTAO
        public TimeSpan CalcularTempoPrevistoTarefasToDo(int idGestor)
        {
            // Seleciona todas as tarefas concluídas pelo gestor com datas válidas
            var tarefasConcluidas = Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.Done && t.IdGestor == idGestor)
                .Where(t => t.DataRealFim >= t.DataRealInicio) // Permite que as datas sejam iguais
                .ToList();

            if (!tarefasConcluidas.Any())
            {
                Console.WriteLine("Nenhuma tarefa concluída válida encontrada. Verifique se DataRealFim está maior ou igual a DataRealInicio.");
                return TimeSpan.Zero;
            }

            // Agrupa as tarefas concluídas por StoryPoints e calcula o tempo médio
            var mediasPorStoryPoints = tarefasConcluidas
                .GroupBy(t => t.StoryPoints)
                .ToDictionary(
                    g => g.Key,
                    g => TimeSpan.FromMinutes(g.Average(t => (t.DataRealFim - t.DataRealInicio).TotalMinutes))
                );

            // Seleciona todas as tarefas pendentes (ToDo) do gestor
            var tarefasToDo = Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.ToDo && t.IdGestor == idGestor)
                .ToList();

            TimeSpan tempoTotalEstimado = TimeSpan.Zero;

            foreach (var tarefa in tarefasToDo)
            {
                // Se houver uma média exata para os StoryPoints da tarefa, usa essa média
                if (mediasPorStoryPoints.TryGetValue(tarefa.StoryPoints, out var media))
                {
                    tempoTotalEstimado += media;
                }
                else
                {
                    // Caso contrário, busca a média mais próxima disponível
                    var storyPointsDisponiveis = mediasPorStoryPoints.Keys.ToList();
                    if (storyPointsDisponiveis.Count > 0)
                    {
                        int spMaisProximo = storyPointsDisponiveis
                            .OrderBy(sp => Math.Abs(sp - tarefa.StoryPoints))
                            .First();

                        tempoTotalEstimado += mediasPorStoryPoints[spMaisProximo];
                    }
                }
            }

            return tempoTotalEstimado;
        }




    }
}








