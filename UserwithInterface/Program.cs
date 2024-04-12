namespace UserwithInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Deməli, programa ilkin olaraq daxil olduqda 3 seçim verir:
             1- daxil ol
             2- qeydiyyat
             3-çıxış
             
             Seçimlərə uyğun olaraq program axışı tamamlanmalı, daxil ola girdikdə adi istifadəçi kimi daxil olunubsa 4 seçim:
             1-profili gpr
             2-profili redaktə et
             3-profili sil
             4-hesabdan çıxış.
             
             Əgər admin kimi daxil olunubsa:
             1- profil əlavə et
             2-seçilmis profili redaktə et
             3-profilləri göstər
             4-seçilmiş profili göstər
             5-seçilmiş profili sil
             6-programdan çıx
             */
            User user = new User();
            UserManager userManager = new UserManager();
            User admin = new User()
            {
                Name = "admin",
                Password = "123"
            };
            userManager.AddUser(admin);
            bool value = true;
            while (value)
            {
                Console.WriteLine("1-Hesaba daxil ol");
                Console.WriteLine("2-Qeydiyyatdan kec");
                Console.WriteLine("3-Proqrami bitir");

                bool trySelect = int.TryParse(Console.ReadLine(), out int selectNum);
                if (trySelect)
                {
                    if (selectNum == 1)
                    {
                        Console.WriteLine("Ad daxil et");
                        string name = Console.ReadLine();
                        Console.WriteLine("Parolu daxil et");
                        string password = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(name) &&
                            !string.IsNullOrWhiteSpace(password))
                        {
                            var allUser = userManager.GetAllUser();
                            bool check = true;
                            bool userFound = false;
                            foreach (var item in allUser)
                            {
                                if (name == "admin" && password == "123")
                                {
                                    userFound = true;
                                    Console.Clear();
                                    Console.WriteLine("Admin xos geldin");
                                    bool adminCheck = true;
                                    while (adminCheck)
                                    {
                                        Console.WriteLine("1-5 Sec");
                                        Console.WriteLine("1-user elave et");
                                        Console.WriteLine("2-useri id-ye gore sil");
                                        Console.WriteLine("3-userleri goster");
                                        Console.WriteLine("4-useri redakte et");
                                        Console.WriteLine("5-Proqrami bitir");
                                        bool tryNum = int.TryParse(Console.ReadLine(), out int num);
                                        if (tryNum)
                                        {
                                            switch (num)
                                            {
                                                case 1:
                                                    Console.WriteLine("Ad daxil et");
                                                    name = Console.ReadLine();
                                                    Console.WriteLine("Soyad daxil et");
                                                    string surName = Console.ReadLine();
                                                    Console.WriteLine("Parolu daxil et");
                                                    password = Console.ReadLine();

                                                    if (!string.IsNullOrWhiteSpace(name) &&
                                                        !string.IsNullOrWhiteSpace(surName) &&
                                                        !string.IsNullOrWhiteSpace(password))
                                                    {

                                                        bool isNameUsed = false;
                                                        foreach (var i in allUser)
                                                        {
                                                            if (item.Name == name)
                                                            {
                                                                isNameUsed = true;
                                                                break;
                                                            }
                                                        }

                                                        if (isNameUsed)
                                                        {
                                                            Console.WriteLine("Istifadeci adi istifade olunub");
                                                        }
                                                        else
                                                        {
                                                            User user1 = new User()
                                                            {
                                                                Name = name,
                                                                Password = password,
                                                                SurName = surName
                                                            };

                                                            userManager.AddUser(user1);
                                                            Console.Clear();
                                                            Console.WriteLine("Qeydiyyatdan basariyla kecdin");
                                                        }
                                                    }
                                                    else
                                                        Console.WriteLine("Datalari duzgun daxil et.");
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Silmek istediyin id-ni daxil et: ");
                                                    int deleteUser = int.Parse(Console.ReadLine());
                                                    Console.Clear();
                                                    userManager.RemoveUser(deleteUser, out string message);
                                                    Console.WriteLine(message);
                                                    break;
                                                case 3:
                                                    allUser = userManager.GetAllUser(user);
                                                    foreach (var i in allUser)
                                                        Console.WriteLine($"{i.Id}. adi: {i.Name}, soyadi: {i.SurName}, parolu:{i.Password}");
                                                    break;
                                                case 4:
                                                    Console.WriteLine("redakte etmek istediyin userin Id daxil et: ");
                                                    int editId = int.Parse(Console.ReadLine());
                                                    bool checkid = false;
                                                    foreach (var users in allUser)
                                                    {
                                                        if (users.Id == editId)
                                                        {
                                                            checkid = true;
                                                            break;
                                                        }
                                                    }
                                                    if (checkid)
                                                    {
                                                        Console.WriteLine("Ad daxil et");
                                                        name = Console.ReadLine();
                                                        Console.WriteLine("Soyad daxil et");
                                                        surName = Console.ReadLine();
                                                        Console.WriteLine("Parolu daxil et");
                                                        password = Console.ReadLine();

                                                        User user2 = new User()
                                                        {
                                                            Id = editId,
                                                            Name = name,
                                                            Password = password,
                                                            SurName = surName
                                                        };
                                                        userManager.UpdateUser(user2);
                                                        Console.Clear();
                                                        Console.WriteLine("Profil redakte edildi");
                                                    }
                                                    else
                                                        Console.Clear();
                                                        Console.WriteLine("Bele id-li istifadeci yoxdu");
                                                    break;
                                                case 5:
                                                    adminCheck = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("1-5e qeder reqem sec");
                                                    break;
                                            }
                                        }
                                        else
                                            Console.WriteLine("Reqem daxil et");
                                    }

                                    break;

                                }
                                if (item.Name == name && item.Password == password)
                                {
                                    userFound = true;
                                    Console.Clear();
                                    Console.WriteLine(name + " hesaba xos geldin");
                                    Console.WriteLine($"{item.Name} , {item.SurName} , {item.Password}");
                                    while (check)
                                    {
                                        Console.WriteLine("1-Redakte et");
                                        Console.WriteLine("2-Hesabi sil");
                                        Console.WriteLine("3-Hesabdan cix");
                                        bool tryGet = int.TryParse(Console.ReadLine(), out int getNum);
                                        if (tryGet)
                                        {
                                            if (getNum == 1)
                                            {
                                                allUser = userManager.GetAllUser();
                                                Console.WriteLine("Ad daxil et");
                                                name = Console.ReadLine();
                                                Console.WriteLine("Soyad daxil et");
                                                string surName = Console.ReadLine();
                                                Console.WriteLine("Parolu daxil et");
                                                password = Console.ReadLine();

                                                User user2 = new User()
                                                {
                                                    Id = item.Id,
                                                    Name = name,
                                                    Password = password,
                                                    SurName = surName
                                                };
                                                userManager.UpdateUser(user2);
                                                Console.WriteLine($"Yeni : {item.Name} , {item.SurName} , {item.Password}");
                                            }
                                            else if (getNum == 2)
                                            {
                                                userManager.RemoveUser(name, out string message);
                                                Console.WriteLine(message);
                                                check = false;
                                                break;
                                            }
                                            else if (getNum == 3)
                                            {
                                                check = false;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("1 2 3 daxil et");
                                            }
                                        }
                                        else
                                            Console.WriteLine("Reqem daxil et");

                                    }
                                    break;
                                }
                            }
                            if (!userFound)
                                Console.WriteLine("Bele hesab tapilmadi");
                        }
                    }
                    else if (selectNum == 2)
                    {
                        Console.WriteLine("Ad daxil et");
                        string name = Console.ReadLine();
                        Console.WriteLine("Soyad daxil et");
                        string surName = Console.ReadLine();
                        Console.WriteLine("Parolu daxil et");
                        string password = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(name) &&
                            !string.IsNullOrWhiteSpace(surName) &&
                            !string.IsNullOrWhiteSpace(password))
                        {
                            var allUser = userManager.GetAllUser();

                            bool isNameUsed = false;
                            foreach (var item in allUser)
                            {
                                if (item.Name == name)
                                {
                                    isNameUsed = true;
                                    break;
                                }
                            }

                            if (isNameUsed)
                            {
                                Console.WriteLine("Istifadeci adi istifade olunub");
                            }
                            else
                            {
                                User user1 = new User()
                                {
                                    Name = name,
                                    Password = password,
                                    SurName = surName
                                };

                                userManager.AddUser(user1);
                                Console.Clear();
                                Console.WriteLine("Qeydiyyatdan basariyla kecdin");
                            }
                        }
                        else
                            Console.WriteLine("Datalari duzgun daxil et.");
                    }
                    else if(selectNum == 3)
                    {
                        value = false;
                    }

                    else
                        Console.WriteLine("1 ve ya 2 daxil et");
                }
                else
                {
                    Console.WriteLine("Datani duzgun daxil et");
                }
            }
        }
    }
}