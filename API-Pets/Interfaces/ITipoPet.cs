using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Interfaces
{
    interface ITipoPet
    {
        TipoPet Cadastrar(TipoPet a);

        List<TipoPet> LerTodos();

        TipoPet BuscarPorId(int id);

        TipoPet Alterar(int id, TipoPet a);

        void Deletar(int id);
    }
}
