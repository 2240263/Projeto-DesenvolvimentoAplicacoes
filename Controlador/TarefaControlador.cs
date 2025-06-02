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

namespace iTasks.Controlador
{
    class TarefaControlador
    {
        public ITaskContext Context { get; set; }
        public TarefaControlador()
        {
            Context = new ITaskContext();
        }

        // metodo para criar o id tarefa na app que vai coincidir com a base de dados
        public int IdTarefa()
        {
            int proximoId;

            using (ITaskContext context = new ITaskContext())
            {
                // Verifica se há tarefas existentes
                if (context.Tarefas.Any())
                {
                    // Pega o maior ID existente
                    proximoId = context.Tarefas.Max(t => t.Id) + 1;
                    return proximoId;
                }
                else
                {
                    // Caso não haja tarefas, inicia com ID 1
                    proximoId = 1;
                    return proximoId;
                }
            }
        }
        
        public void CriarTarefa(int Id) // salva as novas
        {
            {
                Tarefa tarefaNova = new Tarefa();
                // Insere uma nova tarefa
                Context.Tarefas.Add(tarefaNova);
                Context.SaveChanges();

                MessageBox.Show("Nova tarefa criada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public Tarefa CarregarTarefa(int Id)
        {
            try
            {
                // carregar tarefa pelo id
                Tarefa tarefaEncontrada = Context.Tarefas
                                                .Where(t => t.Id == Id)
                                                .FirstOrDefault();

                    return tarefaEncontrada;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a tarefa {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public void GuardaTarefa(Tarefa TarefaAtualizada)
        {
            var tarefaExistente = Context.Tarefas.Find(TarefaAtualizada.Id);
            if (tarefaExistente != null)
            {
                // Atualizar os campos
                tarefaExistente.Descricao = TarefaAtualizada.Descricao;
                tarefaExistente.IdTipoTarefa = TarefaAtualizada.IdTipoTarefa;
                tarefaExistente.IdProgramador = TarefaAtualizada.IdProgramador;
                tarefaExistente.OrdemExecucao = TarefaAtualizada.OrdemExecucao;
                tarefaExistente.StoryPoints = TarefaAtualizada.StoryPoints;
                tarefaExistente.DataPrevistaInicio = TarefaAtualizada.DataPrevistaInicio;
                tarefaExistente.DataPrevistaFim = TarefaAtualizada.DataPrevistaFim;

                Context.SaveChanges();
                MessageBox.Show("Tarefa atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Criar uma nova tarefa
                Context.Tarefas.Add(TarefaAtualizada);
                Context.SaveChanges();
                MessageBox.Show("Nova tarefa salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void AtualizarEstadoTarefa(int Id)
        {
            try
            {
                // carregar tarefa pelo id
                Tarefa tarefaEncontrada = Context.Tarefas
                                                 .Where(t => t.Id == Id)
                                                 .FirstOrDefault();

                if (tarefaEncontrada != null)
                {

                    if (tarefaEncontrada.estadoatual == EstadoAtual.ToDo)
                    { // Incrementar o estado
                        tarefaEncontrada.estadoatual = EstadoAtual.Doing;

                        // atulaizar a data 
                        tarefaEncontrada.DataRealInicio = DateTime.Now;
                    }

                    else if (tarefaEncontrada.estadoatual == EstadoAtual.Doing)
                    {
                        // Incrementar o estado
                        tarefaEncontrada.estadoatual = EstadoAtual.Done;

                        // atulaizar a data 
                        tarefaEncontrada.DataRealFim = DateTime.Now;
                    }

                    // Salvar alterações no banco
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

        // listas para apresentação na view
        public List<TipoTarefa> ListaTiposTarefa()
        {
            return Context.TipoTarefas
               .OrderBy(p => p.Nome) // opcional, ordena por nome
               .ToList();
        }

        public List<Tarefa> ListaToDo()
        {
            return Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.ToDo)
               .OrderBy(p => p.Id) // opcional, ordena por nome
               .ToList();
        }

        public List<Tarefa> ListaDoing()
        {
            return Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.Doing)
               .OrderBy(p => p.Id) // opcional, ordena por nome
               .ToList();
        }

        public List<Tarefa> ListaDone()
        {
            return Context.Tarefas
                .Where(t => t.estadoatual == EstadoAtual.Done)
               .OrderBy(p => p.Id) // opcional, ordena por nome
               .ToList();
        }

        public List<Utilizador> ListaProgramadores()
        {
            return Context.Programadores
               .OrderBy(p => p.Nome) // opcional, ordena por nome
               .Cast<Utilizador>() // Faz o cast para Utilizador
               .ToList();
        }



    }

}








