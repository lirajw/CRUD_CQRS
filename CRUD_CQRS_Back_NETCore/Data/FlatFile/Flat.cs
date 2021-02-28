using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Infra.Data.FlatFile
{
    public class Flat
    {
        public const string ArqCustomer = "CadastroCliente.bin";


        private static List<Customer> _Customer;

        public static List<Customer> CadCustomer
        {
            get
            {
                if (_Customer != null)
                {
                    return _Customer;

                }
                else
                {
                    CadCustomer = GetCadastro<Customer>(ArqCustomer);
                    return _Customer;
                }
            }
            set
            {
                _Customer = value;
            }
        }


        private static List<T> GetCadastro<T>(string Arquivo)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + Arquivo;

            if (File.Exists(path))
            {
                return GetBin<T>(path);
            }
            else
            {
                return new List<T>();
            }

        }

        public static void SetCadastro<T>(List<T> Cadastro, string Arquivo)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + Arquivo;

            SetBin<T>(Cadastro, path);

        }

        private static List<T> GetBin<T>(string Path)
        {
            var json = File.ReadAllText(Path);

            return JsonSerializer.Deserialize<List<T>>(json);

        }

        private static void SetBin<T>(List<T> Cadastro, string Path)
        {
                
            var json = JsonSerializer.Serialize(Cadastro);
            File.WriteAllText(Path, json);                

        }
    }
}
