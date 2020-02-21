using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private string StringConexao = "Data Source=.\\SQLEXPRESS; initial catalog=M_Peoples; Integrated Security=True;";


        public void AlterarViaUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarFun = "UPDATE Funcionarios SET Nome = @Nome," +
                                        "Sobrenome = @Sobrenome WHERE ID_Funcionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryBuscarFun, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }




        public void AlterarViaCorpo(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                FuncionarioDomain funcionarios = new FuncionarioDomain();

                string queryAtualizarId = "UPDATE Funcionarios SET Nome = @Nome," +
                                          "Sobrenome = @Sobrenome WHERE ID_Funcionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.ID_Funcionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }



        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarId = "SELECT * FROM Funcionarios WHERE ID_Funcionario = @ID";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@ID ", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            ID_Funcionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()

                        };
                        return funcionario;
                    }
                }
                return null;
            }

        }





        public void Cadastrar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryCadastrar = "INSERT INTO Funcionarios(Nome,Sobrenome) VALUES (@Nome,@Sobrenome)";


                SqlCommand cmd = new SqlCommand(queryCadastrar, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }




        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM Funcionarios WHERE ID_Funcionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }




        public List<FuncionarioDomain> ListarFuncionarios()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGetAll = "SELECT ID_Funcionario, Nome, Sobrenome FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryGetAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            ID_Funcionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }

                }
                return funcionarios;
            }
        }



        public FuncionarioDomain RetornarNome(string Nome)
        {
            FuncionarioDomain funcionarios = new FuncionarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                string queryGetByName = "SELECT ID_Funcionario, Nome, Sobrenome WHERE Nome LIKE " + '%' + @Nome + '%';
                


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryGetByName, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        funcionarios.ID_Funcionario = Convert.ToInt32(rdr["ID_Funcionario"]);
                        funcionarios.Nome = rdr["Nome"].ToString() + " "
                        + rdr["Sobrenome"].ToString();
                        funcionarios.DtaNascimento = rdr["DtaNascimento"].ToString();
                    }
                }
                return funcionarios;
            }
        }
       

        public List<FuncionarioDomain> RetornarFunASC()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryOrderAsc = "EXEC ordemnsASC";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryOrderAsc, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        FuncionarioDomain funcionario = new FuncionarioDomain();

                        funcionario.ID_Funcionario = Convert.ToInt32(rdr["ID_Funcionario"]);
                        funcionario.Nome = rdr["Nome"].ToString();
                        funcionario.Sobrenome = rdr["Sobrenome"].ToString();
                        funcionario.DtaNascimento = rdr["DtaNascimento"].ToString();

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
    }
}


