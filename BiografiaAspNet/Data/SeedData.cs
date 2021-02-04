using BiografiaAspNet.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiografiaAspNet.Data
{
    public class SeedData
    {
        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "joaonunes@upskill.pt";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Secret123$";

        private const string ROLE_ADIMINISTRADOR = "Administrador";
        private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_GESTOR_PRODUTOS = "GestorProdutos";

        internal static void InsereExpProfissionalFicticios(BiografiaAspNetDbContext _db)
        {
            if (_db.DadosPessoais.Any()) return;

            _db.DadosPessoais.AddRange(new DadosPessoais[] {
                new DadosPessoais
                {
                    Nome = "João Nunes",
                    DataNascimento = "12/01/1994",
                    Naturalidade = "Oliveira do Hospital",
                    Nacionalidade = "Portuguesa"
                },
                new DadosPessoais
                {
                    Nome = "Maria Antónia",
                    DataNascimento = "30/11/1999",
                    Naturalidade = "Porto",
                    Nacionalidade = "Espanhola"
                },
                new DadosPessoais
                {
                    Nome = "Maria Antónia",
                    DataNascimento = "30/11/1999",
                    Naturalidade = "Porto",
                    Nacionalidade = "Espanhola"
                },
                new DadosPessoais
                {
                    Nome = "Maria Antónia",
                    DataNascimento = "30/11/1999",
                    Naturalidade = "Porto",
                    Nacionalidade = "Espanhola"
                },
                new DadosPessoais
                {
                    Nome = "Mario Gonçalves",
                    DataNascimento = "30/11/1999",
                    Naturalidade = "Porto",
                    Nacionalidade = "Espanhola"
                },
                new DadosPessoais
                {
                    Nome = "Ana Maria",
                    DataNascimento = "30/11/1999",
                    Naturalidade = "Porto",
                    Nacionalidade = "Espanhola"
                },
                new DadosPessoais
                {
                    Nome = "José Fonseca",
                    DataNascimento = "01/01/2000",
                    Naturalidade = "Lisboa",
                    Nacionalidade = "Portuguesa"
                }
            });
        }

        //internal static void InsereExpProfissionalFicticios(BiografiaAspNetDbContext _db, DadosPessoais pessoa)
        //{
        //    if (_db.ExperienciaProfissional.Any()) return;

        //    _db.ExperienciaProfissional.AddRange(new ExpProfissional[] {
        //        new ExpProfissional
        //        {
        //            Entidade = "Knegra",
        //            Periodo = "3 anos",
        //            Funcoes = "Knegra",
        //            DadosPessoais = pessoa
        //        },
        //        new ExpProfissional
        //        {
        //            Entidade = "AAG",
        //            Periodo = "2 anos",
        //            Funcoes = "Presidente da Direção",
        //            DadosPessoais = pessoa
        //        },
        //        new ExpProfissional
        //        {
        //            Entidade = "IPG",
        //            Periodo = "1 ano",
        //            Funcoes = "Funcionária de limpeza",
        //            DadosPessoais = pessoa

        //        },
        //        new ExpProfissional
        //        {
        //            Entidade = "Meo",
        //            Periodo = "3 ano",
        //            Funcoes = "Consultora",
        //            DadosPessoais = pessoa
        //        },
        //        new ExpProfissional
        //        {
        //            Entidade = "EPD",
        //            Periodo = "3 meses",
        //            Funcoes = "Contagem",
        //            DadosPessoais = pessoa
        //        },
        //    });
        //    _db.SaveChanges();
        //}

        internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "joao@ipg.pt", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

            IdentityUser gestor = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "maria@ipg.pt", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, gestor, ROLE_GESTOR_PRODUTOS);
        }

        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {
            await CriaRoleSeNecessario(gestorRoles, ROLE_ADIMINISTRADOR);
            await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
            await CriaRoleSeNecessario(gestorRoles, ROLE_GESTOR_PRODUTOS);
        }

        private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
        {
            if (!await gestorRoles.RoleExistsAsync(funcao))
            {
                IdentityRole role = new IdentityRole(funcao);
                await gestorRoles.CreateAsync(role);
            }
        }

        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            string nomesUtilizador = NOME_UTILIZADOR_ADMIN_PADRAO;
            string passwordUtilizador = PASSWORD_UTILIZADOR_ADMIN_PADRAO;
            IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, nomesUtilizador, passwordUtilizador);


            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADIMINISTRADOR);

        }

        private static async Task AdicionaUtilizadorRoleSeNecessario(UserManager<IdentityUser> gestorUtilizadores, IdentityUser utilizador, string role)
        {
            if (!await gestorUtilizadores.IsInRoleAsync(utilizador, role))
            {
                await gestorUtilizadores.AddToRoleAsync(utilizador, role);
            }
        }

        private static async Task<IdentityUser> CriaUtilizadorSeNaoExiste(UserManager<IdentityUser> gestorUtilizadores, string nomeUtilizador, string password)
        {
            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(nomeUtilizador);

            if (utilizador == null)
            {
                utilizador = new IdentityUser(nomeUtilizador);
                await gestorUtilizadores.CreateAsync(utilizador, password);
            }

            return utilizador;
        }


    }
}
