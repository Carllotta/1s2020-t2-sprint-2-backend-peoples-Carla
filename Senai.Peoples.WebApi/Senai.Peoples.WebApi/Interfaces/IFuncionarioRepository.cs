using Senai.Peoples.WebApi.Domains;
using System.Collections.Generic;


namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> ListarFuncionarios();

        FuncionarioDomain BuscarPorId(int id);

        void Cadastrar(FuncionarioDomain funcionario);

        void AlterarViaUrl(int id, FuncionarioDomain funcionario);

        void AlterarViaCorpo(FuncionarioDomain funcionario);
        
        void Deletar(int id);

        List<FuncionarioDomain> RetornarFunASC();

        FuncionarioDomain RetornarNome(string nome);

     }
}
