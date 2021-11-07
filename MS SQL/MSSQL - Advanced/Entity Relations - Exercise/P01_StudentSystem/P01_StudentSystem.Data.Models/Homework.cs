﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(300)")]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }
        
        public DateTime SubmissionTime { get; set; }
        
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
