using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDMatrix.Models
{
    public class Employee
    {
        
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Campo obrigatório P#RRA!")]
        // Comando utilizado para Deixar o campo obrigatório ao salvar 
        [DisplayName("Nome Completo")]
   
        public string FullName { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Matricula")]

        public int EmpCode { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Cargo")]

        public string Position { get; set; }
        [Column(TypeName = "nvarchar(100)")]


        [DisplayName("Localização")]
        public string OfficeLocation { get; set; }


    }
}
