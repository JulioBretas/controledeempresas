using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Interfaces
{
    /// <summary>
    /// Interface padrão para repositórios do sistema
    /// </summary>
    /// <typeparam name="T">Tipo genérico que representa a entidade</typeparam>
    public interface IRepository<T>
    {
        void Inserir(T obj);
        List<T> Consultar();
    }
}
