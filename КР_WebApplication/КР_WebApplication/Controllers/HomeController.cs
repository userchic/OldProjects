using CPWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public static Users user = new Users();
        public static GameContext db = new GameContext();
        public static MakeGame CurrentMakeG = new MakeGame() { Tasks = new List<Tasks>() };
        public ActionResult Main()
        {
            return View("Main");
        }
        public ActionResult CancelMakeGame()
        {
            CurrentMakeG = new MakeGame() { Tasks = new List<Tasks>() };
            return View("GameMake",CurrentMakeG);
        }
        [HttpPost]
        public ActionResult LoginClick(string Login,string password)
        {
            if (password != null & Login != null & password != "" & Login != "")
            {
                var us = db.Users.FirstOrDefault(u => u.Login == Login & u.Password == password);
                if (us != null)
                {
                    user.Login = us.Login;
                    user.Name = us.Name;
                    user.Password = us.Password;
                    user.Fatname = us.Fatname;
                    user.ID = us.ID;
                    user.Class = us.Class;
                    user.Role = us.Role;
                    user.Surname = us.Surname;
                    ViewBag.Message = "";
                    return View("Main");
                }
                else
                {
                    ViewBag.Message = "Введены данные несуществующего пользователя, введите другие данные";
                    return View("Login", new Users() { Login = "", Password = "" });
                }
            }
            else
            {
                ViewBag.Message = "Не все поля были заполнены, введите логин И пароль";
                return View("Login", new Users() { Login = Login, Password = password });
            }
        }
        [HttpPost]
        public ActionResult AddTaskClick(string Text, string RightAnswer)
        {
            if (Text != "" & RightAnswer != "")
            {
                CurrentMakeG.Tasks.Add(new Tasks() { RightAnswer = RightAnswer, Text = Text });
                return View("GameMake", CurrentMakeG);
            }
            else
            {
                ViewBag.Message = "Текст или ответ задачи не введены";
                return View("TaskMake", new Tasks() { RightAnswer = RightAnswer, Text = Text });
            }
        }
        [HttpPost]
        public ActionResult AddGameClick(string GameName, string StartData, string Lenga, string StartHour, string StartMinute, string action)
        {
            if (action == "AddGame")
            {
                DateTime t;
                int num;
                string message = "";
                if (GameName != "" & StartData != "" & Lenga != "" & StartHour != "" & StartMinute != "" & DateTime.TryParse(StartData, out t) & int.TryParse(Lenga, out num) && int.TryParse(StartHour, out num) && int.TryParse(StartMinute, out num) & CurrentMakeG.Tasks.Count > 0)
                {
                    CurrentMakeG.GameName = GameName;
                    CurrentMakeG.StartData = DateTime.Parse(StartData);
                    CurrentMakeG.Lenga = int.Parse(Lenga);
                    CurrentMakeG.StartHour = int.Parse(StartHour);
                    CurrentMakeG.StartMinute = int.Parse(StartMinute);
                    Game game = new Game() { GameName = GameName, Lenga = int.Parse(Lenga), StartData = DateTime.Parse(StartData), StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(StartHour), int.Parse(StartMinute), 0) };
                    db.Games.Add(game);
                    for (int i = 0; i < CurrentMakeG.Tasks.Count; i++)
                    {
                        Tasks task = new Tasks() { Text = CurrentMakeG.Tasks[i].Text, RightAnswer = CurrentMakeG.Tasks[i].RightAnswer ,Game=game};
                        db.Tasks.Add(task);
                        game.TasksList.Add(task);
                    }
                    CurrentMakeG.Tasks.Clear();
                    db.SaveChanges();
                    return View("Main");
                }
                else
                {
                    MakeGame g = CurrentMakeG;
                    ViewBag.Message = "Некоторые поля были неправильно заполнены:";
                    if (GameName == "")
                        ViewBag.Message += "Не указано название игры ";
                    if (StartData != "")
                    {
                        if (DateTime.TryParse(StartData, out t))
                            g.StartData = DateTime.Parse(StartData);
                        else
                            ViewBag.Message += " Неправильно введена дата проведения";
                    }
                    else
                        ViewBag.Message += "Не указана дата начала игры ";
                    if (Lenga != "")
                    {
                        if (int.TryParse(Lenga, out num))
                            g.Lenga = int.Parse(Lenga);
                        else
                            ViewBag.Message += "Неправильно введена длительность игры ";
                    }
                    else
                        ViewBag.Message += "Не указана длительность игры";
                    if (StartHour != "")
                    {
                        if (int.TryParse(StartHour, out num))
                            g.StartHour = int.Parse(StartHour);
                        else
                            ViewBag.Message += "Неправильно введен час начала игры";
                    }
                    else
                        ViewBag.Message += "Не указан час начала игры";
                    if (StartMinute != "")
                    {
                        if (int.TryParse(StartMinute, out num))
                            g.StartMinute = int.Parse(StartMinute);
                        else
                            ViewBag.Message += "Неправильно введена минута начала игры";
                    }
                    else
                            ViewBag.Message += "Не указана минута начала игры";
                    ViewBag.Message += "\nВведите информацию в эти поля ещё раз";
                    if (CurrentMakeG.Tasks.Count == 0)
                        ViewBag.Messge += "\nНе создано ни одной задачи! Создайте хотя бы одну задачу для создаваемой игры";
                    return View("GameMake", g);
                }
            }
            else
            {
                if (action == "AddTask")
                {
                    try
                    {
                        CurrentMakeG.GameName = GameName;
                    }
                    catch{ }
                    try
                    {
                        CurrentMakeG.StartData = DateTime.Parse(StartData);
                    }
                    catch{ }
                    try
                    { 
                        CurrentMakeG.Lenga = int.Parse(Lenga);
                    }
                    catch{ }
                    try
                    { 
                        CurrentMakeG.StartHour = int.Parse(StartHour);
                    }
                    catch{ }
                    try
                    { 
                        CurrentMakeG.StartMinute = int.Parse(StartMinute);
                    }
                    catch{ }
                    return View("TaskMake", new Tasks());
                }
                else
                {
                    CurrentMakeG = new MakeGame(){ Tasks = new List<Tasks>()};
                    return View("GameMake", CurrentMakeG);
                }
            }
        }
        public ActionResult Cancelmaketask()
        {
            return View("GameMake",CurrentMakeG);
        }
        public ActionResult Tasks()
        {
            return View("Tasks");
        }
        public ActionResult Login()
        {
            return View("Login",new Users());
        }
        public ActionResult AddGame()
        {
            return View("GameMake",CurrentMakeG);
        }
        public ActionResult AddTask(MakeGame model)
        {
            return View("TaskMake");
        }


        public ActionResult TaskInfo(string TaskID)
        {
            int ID = int.Parse(TaskID);
            Tasks t = db.Tasks.FirstOrDefault(Task => Task.ID == ID);
            return View("Task",t);
        }
    }
}