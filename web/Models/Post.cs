using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yy H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Created { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yy H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? LastEdit { get; set; }
        public int CategoryId { get; set; }
        public ApplicationUser? Owner { get; set; }

        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        //public virtual ICollection<PostReply> PostReplies { get; set; }

        public string Kategorija(int st_kategorije){
            string ime_kategorije = "";
            switch(st_kategorije){
                case 1:
                    ime_kategorije = "Splošno";
                    break;

                case 2:
                    ime_kategorije = "Predavanja";
                    break;
                                    
                case 3:
                    ime_kategorije = "Naloge";
                    break;
                                    
                case 4:
                    ime_kategorije = "Diskusije";
                    break;
            }
            return ime_kategorije;
        }
    }
}