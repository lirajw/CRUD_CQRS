using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_CQRS.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Idade Obrigatória")]
        [DisplayName("Birth Date")]
        public int Age { get; private set; }

        [Required(ErrorMessage = "Telefone Obrigatório")]
        [Phone]
        [DisplayName("Telefone para Contato")]
        public int Telephone { get; private set; }

        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }                      

        public int CEP { get; private set; }
        public string Address { get; private set; }
        public int Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
    }
}
