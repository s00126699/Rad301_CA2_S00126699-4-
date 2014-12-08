using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S00126699_CA2.Models
{

    public class DbInitialiser : DropCreateDatabaseAlways<MovieDb>
    {
        protected override void Seed(MovieDb context)
        {
            
            //Movie mov1 = new Movie() { MoviesName = "Tits", Actors = new List<Actor> { new Actor() { ActorsName = "Guy", ScreenName = "thatguy" } } };

            var seedMovieData = new List<Movie>
            {

             new Movie() { MoviesName="Terminator", Description="He'd be back!",
             
                Actors = new List<Actor>()
             {
                 new Actor() { ActorsName="Arnold Schwenngar", 
                               ScreenName="T100"},
                               new Actor() { ActorsName="Emilia Clarke", ScreenName="Sarah Connors"}
             }

            },

            new Movie() { MoviesName="Godfather", Description="An offer you can't refuse",
             
                Actors = new List<Actor>()
             {
                 new Actor() { ActorsName="Al Pacino", 
                               ScreenName="Michael Corleone"}
             }

            },
            new Movie() { MoviesName="For a fistfull of dollars", Description="Two gangs and one mercanary",
             
                Actors = new List<Actor>()
             {
                 new Actor() { ActorsName="Clint Eastwood", 
                               ScreenName="Man with No Name"},
                               new Actor()
                               { ActorsName="Gian Maria Volonté", ScreenName="Ramone"}
             }

            },

            new Movie() { MoviesName="For a few dollars more ", Description="One gang of Outlaws!, Two Mercanarys",
             
                Actors = new List<Actor>()
             {
                 new Actor() { ActorsName="Clint Eastwood", 
                               ScreenName="Man with No Name"},
                               new Actor()
                               { ActorsName="Gian Maria Volonté", ScreenName="El Indio"},
                               new Actor() { ActorsName="Lee Van Cleef", ScreenName="Colonel Douglas Mortimer"}
             }

            },

            new Movie() { MoviesName="ScarFace", Description="Say Hello To My later Friend!"
            , Actors = new List<Actor>()
            {
                new Actor() { ActorsName="Al Pacino", ScreenName="Tony Montanna"},
                new Actor() {ActorsName="Robert Loggia", ScreenName="Frank Lopaz"}
            }}

            };
            seedMovieData.ForEach(mov => context.Movies.Add(mov));

            context.SaveChanges();
            base.Seed(context);
          
        }
    }
  
    //            new Ward() {WardTitle = "Ward Alpha" , WardCreation = DateTime.Parse("3/10/2014") , Patients = 
    //                new List<Patient>()
    //                {
    //                    new Patient() {PatientName = "Sarah Connor", PatientGender = "F" } 
    //                }

    //            },
    //            new Ward() {WardTitle = "Ward Beta"}
    //            };
    //        seedWardData.ForEach(wards => context.Wards.Add(wards));
    //        context.SaveChanges();
    //    }
    //}



    #region Movie
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Movie Name must be at least 2 characters long.", MinimumLength = 2)]
        [Display(Name = "Movie Name")]
        public string MoviesName { get; set; }

        //[Display(Name = "Release Date")]
        //public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Description"), StringLength(200)]
        public string Description { get; set; }

        public ICollection<Actor> Actors { get; set; }
    }
    #endregion

    #region Actor
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        public int MovieID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Actors Name must be at least {0} characters long.", MinimumLength = 3)]
        [Display(Name = "Actors Name")]
        public string ActorsName { get; set; }


        //public string ActorBio { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Screen Name must be at least {0} characters long.", MinimumLength = 3)]
        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }

    }
    #endregion

    #region DbContext
    public class MovieDb : DbContext
    {
        public MovieDb()
            : base("MovieDb")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
    #endregion
}