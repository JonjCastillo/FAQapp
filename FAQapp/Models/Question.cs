using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FAQapp.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Enter a question")]
        public string? QuestionText { get; set; }

        [Required (ErrorMessage = "Enter a category")]
        public string? Category { get; set; }

        [Required (ErrorMessage = "Enter a Topic")]
        public string? Topic { get; set; }
        public string? Answer { get; set; }
    }
}
