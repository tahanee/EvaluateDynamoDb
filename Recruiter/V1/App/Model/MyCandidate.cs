using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace CandidateModel.Models
{    public class MyCandidate
    { 
        [Key]
        public string Id { get; set; }
        public string ResourceRequisition { get; set; }
        public string CandidateEmail { get; set; }
        public int Stages { get; set; }
        public string ResumeText{get;set;}
        public string ResumeUpload{get;set;}
        public DateTime PanelDeadline { get; set; }
        
    }
}