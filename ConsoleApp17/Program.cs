namespace ConsoleApp17
{
    namespace SomeAnotherNameSpace
    {
        class Program
        {
            public static void Main()
            {/*
                List<Worker> workers = new List<Worker>();  
                Worker worker = new Worker {
                    FirstName = "Абоба",
                    LastName = "Гулизяка",
                    Patronymic = "Ефимовна",
                    Birthday = new DateTime(2000, 2, 29).ToBinary(),
                    Phone = "отсутствует"
                };
                workers.Add(worker);
                worker = new Worker
                {
                    FirstName = "Гуля",
                    LastName = "Гофман",
                    Patronymic = "Абрамович",
                    Birthday = new DateTime(1900, 1, 1).ToBinary(),
                    Phone = "+76666666666"
                };
                workers.Add(worker);
                worker = new Worker
                {
                    FirstName = "Гугл",
                    LastName = "Яндекс",
                    Patronymic = "Мейлович",
                    Birthday = new DateTime(2024, 1, 1).ToBinary(),
                    Phone = "будет"
                };
                workers.Add(worker);

                using (var fs = File.Create("workers"))
                using (var bw = new BinaryWriter(fs))
                {
                    foreach (var w in workers)
                    {
                        bw.Write(w.FirstName);
                        bw.Write(w.LastName);                                    
                        bw.Write(w.Patronymic);
                        bw.Write(w.Birthday);
                        bw.Write(w.Phone);
                    }
                }
                */
                string search = Console.ReadLine();
                using (var fs = File.OpenRead("workers"))
                using (var br = new BinaryReader(fs))
                {
                    while (fs.Position < fs.Length)
                    {
                        Worker worker = new Worker
                        {
                            FirstName = br.ReadString(),
                            LastName = br.ReadString(),
                            Patronymic = br.ReadString(),
                            Birthday = br.ReadInt64(),
                            Phone = br.ReadString()
                        };
                        if (worker.FirstName.Contains(search) ||
                            worker.Patronymic.Contains(search) ||
                            worker.LastName.Contains(search))
                        {
                            Console.WriteLine($"{worker.FirstName} {worker.Patronymic} {worker.LastName} " +
                                $"{worker.Phone} {DateTime.FromBinary(worker.Birthday).ToShortDateString()}");
                        }
                    }
                }
            }
        }
    }
}