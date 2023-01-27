using ProjetoAula05.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula05.Entities
{
    /// <summary>
    /// Modelo de entidade para Funcionário
    /// </summary>
    public class Funcionario
    {
        #region Atributos

        private Guid _id;
        private string? _nome;
        private string? _cpf;
        private string? _matricula;
        private DateTime? _dataAdmissao;
        private StatusFuncionario? _status;
        private Guid _idEmpresa;
        private Empresa? _empresa;

        #endregion

        #region Propriedades

        public Guid Id {
            set {
                if (value == Guid.Empty)
                    throw new ArgumentException("O Id do funcionário não pode ser vazio.");

                _id = value;
            }
            get => _id;
        }

        public string? Nome {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O Nome do funcionário não pode ser vazio.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,150}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Nome do funcionário é inválido.");

                _nome = value;
            }
            get => _nome;
        }

        public string? Cpf {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O CPF do funcionário não pode ser vazio.");

                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("CPF do funcionário é inválido. Informe 11 dígitos numéricos.");

                _cpf = value;
            }
            get => _cpf;
        }

        public string? Matricula {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A Matrícula do funcionário não pode ser vazio.");

                var regex = new Regex("^[0-9]{4,8}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Matrícula do funcionário é inválido. Informe de 4 a 8 dígitos numéricos.");

                _matricula = value;
            }
            get => _matricula;
        }

        public DateTime? DataAdmissao {
            set { _dataAdmissao = value; }
            get => _dataAdmissao;
        }

        public StatusFuncionario? Status {
            set { _status = value; }
            get => _status;
        }

        public Guid IdEmpresa {
            set { _idEmpresa = value; }
            get => _idEmpresa;
        }

        public Empresa? Empresa {
            set { _empresa = value; }
            get => _empresa;
        }

        #endregion
    }
}
