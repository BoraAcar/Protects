using MyEvernoteDataAccessLayer;
using MyEvernoteDataAccessLayer.EntityFramework;
using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteBusinessLayer
{
    public class Test
    {
        private Repository<Category> repo_category = new Repository<Category>();
        private Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        private Repository<Comment> repo_comment = new Repository<Comment>();
        private Repository<Note> repo_note = new Repository<Note>();

        public Test()
        {

            List<Category> categories=repo_category.List();
        }

        public void InsertTest()
        {
            EvernoteUser userr = new EvernoteUser();

            userr.Name = "aaa";
            userr.Surname = "bbb";
            userr.Email = "udemy@gmail.com";
            userr.ActivateGuid = Guid.NewGuid();
            userr.IsActive = true;
            userr.IsAdmin = true;
            userr.Username = "aabb";
            userr.Password = "111";
            userr.CreatedOn = DateTime.Now;
            userr.ModifiedOn = DateTime.Now.AddMinutes(5);
            userr.ModifiedUserName = "aabbb";

            int result = repo_user.Insert(userr);
        }

        public void UpdateTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "aabb");

            if(user!=null)
            {
                user.Username = "xxxx";
                int result=repo_user.Save();
            }
        }

        public void CommentTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "xxxx");
            Note note = repo_note.Find(x => x.id == 3);

            Comment comment = new Comment();

            comment.Text = "bu bir test..";
            comment.CreatedOn = DateTime.Now;
            comment.ModifiedOn = DateTime.Now.AddMinutes(10);
            comment.ModifiedUserName = "bora55";
            comment.Note = note;
            comment.Owner = user;

            repo_comment.Insert(comment);
        }
    }
}
 