using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernoteEntities;

namespace MyEvernoteDataAccessLayer.EntityFramework
{
    public class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            EvernoteUser admin = new EvernoteUser();
            admin.Name = "Bora";
            admin.Surname = "Acar";
            admin.Username = "Bora55";
            admin.Email = "boraacar95@gmail.com";
            admin.ActivateGuid = Guid.NewGuid();
            admin.IsActive = true;
            admin.IsAdmin = true;
            admin.Password = "123b123_";
            admin.CreatedOn = DateTime.Now;
            admin.ModifiedOn = DateTime.Now.AddMinutes(5);
            admin.ModifiedUserName = "Bora55";

            EvernoteUser StandartUser = new EvernoteUser();
            StandartUser.Name = "Kadir";
            StandartUser.Surname = "Öney";
            StandartUser.Username = "Kadir34";
            StandartUser.Email = "tuzlali.kadir_231@hotmail.com";
            StandartUser.ActivateGuid = Guid.NewGuid();
            StandartUser.IsActive = true;
            StandartUser.IsAdmin = false;
            StandartUser.Password = "borakado123";
            StandartUser.CreatedOn = DateTime.Now.AddHours(1);
            StandartUser.ModifiedOn = DateTime.Now.AddMinutes(6);
            StandartUser.ModifiedUserName = "Bora55";
           

            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(StandartUser);

            for (int i = 0; i < 8; i++)
            {
                EvernoteUser user = new EvernoteUser();
                user.Name = FakeData.NameData.GetFirstName();
                user.Surname = FakeData.NameData.GetSurname();
                user.Username = $"user{i}"; // yeni kullanım.
                user.Email = FakeData.NetworkData.GetEmail();
                user.ActivateGuid = Guid.NewGuid();
                user.IsActive = true;
                user.IsAdmin = false;
                user.Password = "123";
                user.CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now);
                user.ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now);
                user.ModifiedUserName = $"user{i}";

                context.EvernoteUsers.Add(user);
            }

            context.SaveChanges();

            List<EvernoteUser> userlist = context.EvernoteUsers.ToList();

            //Adding 10 FakeData Category

            for (int i = 0; i < 10; i++)
            {

                Category cat = new Category();

                cat.Title = FakeData.PlaceData.GetStreetName();
                cat.Description = FakeData.PlaceData.GetAddress();
                cat.CreatedOn = DateTime.Now;
                cat.ModifiedOn = DateTime.Now;
                cat.ModifiedUserName = "bora55";

                context.Categories.Add(cat);

                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    EvernoteUser owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                    Note note = new Note();
                    note.Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25));
                    note.Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3));
                    note.Category = cat;
                    note.IsDraft = false;
                    note.LikeCount = FakeData.NumberData.GetNumber(1, 9);
                    note.Owner = owner;
                    note.CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now);
                    note.ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now);
                    note.ModifiedUserName = owner.Username;

                    cat.Notes.Add(note);
                    context.Notes.Add(note);

                    for (int j = 0; j < FakeData.NumberData.GetNumber(1,5); j++)
                    {
                        EvernoteUser comment_owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                        Comment comment = new Comment();
                        comment.Text = FakeData.TextData.GetSentence();
                        comment.Owner = comment_owner; // bunlar yazılmasa da olur zaten note.comment.Add deyince o notun yorumuna sahibi direk atanır..
                        comment.CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now);
                        comment.ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now);
                        comment.ModifiedUserName = comment_owner.Username;

                        note.Comments.Add(comment);
                        context.Comments.Add(comment);

                    }

                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        Liked likes = new Liked();

                        likes.LikedUser = userlist[m];

                        note.Likes.Add(likes);
                        context.Likes.Add(likes);
                    }
                }
            }

            context.SaveChanges();

        }
    }
}