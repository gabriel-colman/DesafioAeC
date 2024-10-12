using DesafioAeC.Domain.Entities;

namespace DesafioAeC.Application.DTOs
{
    public class CourseDTO
    {
        // Propriedade para o t�tulo do curso
        public string Title { get; set; }

        // Propriedade para o nome do professor
        public string Professor { get; set; }

        // Propriedade para a carga hor�ria
        public string Duration { get; set; }

        // Propriedade para a descri��o do curso
        public string Description { get; set; }

        // Construtor que inicializa as propriedades
        public CourseDTO(string title, string professor, string duration, string description)
        {
            Title = title;
            Professor = professor;
            Duration = duration;
            Description = description;
        }

        // M�todo para converter o DTO em uma entidade Course
        public Course ToEntity()
        {
            return new Course(Title, Professor, Duration, Description);
        }
    }
}
