using Microsoft.EntityFrameworkCore;
namespace CandidateModel.Models
{    public class Candidate
    {
        public string Id { get; set; }
        public string Job_Requisition { get; set; }
        public string Email { get; set; }
        public int Stages { get; set; }
        public string File_Name{get;set;}
        public System.DateTime Deadline { get; set; }
        
    }
}