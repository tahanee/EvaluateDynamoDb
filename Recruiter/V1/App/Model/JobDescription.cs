using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Models.Recruiter
{
public class ResourceRequisition
{
    [Key]
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string HiringManagerEmail { get; set; }
     public string Notes { get; set; }
     public string Skills { get; set; }
     public int Stages { get; set; }     
     public DateTime PlannedDeadline { get; set; }

}
}
