using System.ComponentModel.DataAnnotations;

namespace BestCodder.Models;

public class CourseDto
{
    [Key] public int Id { get; set; }
    
    [Required] public string? Name { get; set; }
    
    [Required(ErrorMessage = "Price must be have fill")] public decimal CoursePrice { get; set; }
    
    [Required(ErrorMessage = "Must be selected isActive")] public bool IsActive { get; set; }
    public string? Description { get; set; }
    
    [Required] public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public double RegularRate { get; set; }
    public string? Details { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string? ImageUrl { get; set; }
    public int TotalCount { get; set; }
}