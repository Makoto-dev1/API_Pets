using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca r);
        List<Raca> LerTodos();
        Raca Alterar(int id, Raca r);
        void Deletar(int id);
        Raca BuscarPorId(int id);
    }
}
