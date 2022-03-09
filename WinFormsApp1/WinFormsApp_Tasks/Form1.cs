using System.Collections.Concurrent;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> _strs = new List<string>();

        void RunMyFunc(Action func)
        {
            _strs.Clear();
            func();
            textBox1.Text = String.Join(Environment.NewLine, _strs);
        }

        //object lockObject = new object();
        //void AddStr(string added_str)
        //{
        //    lock (lockObject)
        //    {
        //        _strs.Add(added_str);
        //    }
        //}

        private readonly SemaphoreSlim globalLock = new SemaphoreSlim(1);
        void AddStr(string added_str)
        {
            globalLock.Wait();

            _strs.Add(added_str);

            globalLock.Release();
        }

        //private readonly Semaphore globalLock = new Semaphore(1, 1);
        //void AddStr(string added_str)
        //{
        //    globalLock.WaitOne();

        //    _strs.Add(added_str);

        //    globalLock.Release();
        //}

        //public List<KeyValuePair<long, string>> _strs = new List<KeyValuePair<long, string>>();
        //void RunMyFunc(Action func)
        //{
        //    _strs.Clear();
        //    func();
        //    textBox1.Text = String.Join(Environment.NewLine, _strs.OrderBy(it => it.Key).Select(it => it.Value));
        //}
        //void AddStr(string added_str)
        //{
        //    _strs.Add(new KeyValuePair<long, string>(DateTime.Now.Ticks, added_str));
        //}

        //private void sub2()
        //{
        //    sub1();
        //}
        //private async void sub1()
        //{
        //    await Task.Yield();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                Task
                    .Run(async () =>
                    {
                        await Task.WhenAll(
                            new Func<Task>(async () =>
                            {
                                AddStr(DateTime.Now.ToString() + ". func2. 1");
                                await Task.Delay(100);
                                AddStr(DateTime.Now.ToString() + ". func2. 2");
                            })()
                            ,
                            new Func<Task>(async () =>
                            {
                                AddStr(DateTime.Now.ToString() + ". func3. 1");
                                await Task.Delay(50);
                                AddStr(DateTime.Now.ToString() + ". func3. 2");
                            })()
                            );
                    })
                    .Wait()
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                Task
                    .Run(async () =>
                    {
                        await Task.WhenAll(
                            new Func<Task>(async () =>
                            {
                                //https://ru.stackoverflow.com/questions/652137/%D0%A7%D1%82%D0%BE-%D1%82%D0%B0%D0%BA%D0%BE%D0%B5-task-yield
                                await Task.Yield();
                                //await Task.Run(() => { });
                                AddStr(DateTime.Now.ToString() + ". func2. 1");
                                //await Task.Delay(100);
                                Task.Delay(100).Wait();
                                AddStr(DateTime.Now.ToString() + ". func2. 2");
                            })()
                            ,
                            new Func<Task>(async () =>
                            {
                                await Task.Yield();
                                //await Task.Run(() => { });
                                AddStr(DateTime.Now.ToString() + ". func3. 1");
                                //await Task.Delay(50);
                                Task.Delay(50).Wait();
                                AddStr(DateTime.Now.ToString() + ". func3. 2");
                            })()
                            );
                    })
                    .Wait()
                );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                Task
                    .Run(async () =>
                    {
                        await Task.WhenAll(
                            new Func<Task>(async () =>
                            {
                                await Task.Run(() => { });
                                AddStr(DateTime.Now.ToString() + ". func2. 1");
                                Task.Delay(100).Wait();
                                AddStr(DateTime.Now.ToString() + ". func2. 2");
                            })()
                            ,
                            new Func<Task>(async () =>
                            {
                                await Task.Run(() => { });
                                AddStr(DateTime.Now.ToString() + ". func3. 1");
                                Task.Delay(50).Wait();
                                AddStr(DateTime.Now.ToString() + ". func3. 2");
                            })()
                            );
                    })
                    .Wait()
                );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                Task
                    .Run(async () =>
                    {
                        await Task.WhenAll(
                            new Func<Task>(async () =>
                            {
                                await Task.CompletedTask; // не передаёт управление вышестоящей функции
                                AddStr(DateTime.Now.ToString() + ". func2. 1");
                                Task.Delay(100).Wait();
                                AddStr(DateTime.Now.ToString() + ". func2. 2");
                            })()
                            ,
                            new Func<Task>(async () =>
                            {
                                await Task.CompletedTask;
                                AddStr(DateTime.Now.ToString() + ". func3. 1");
                                Task.Delay(50).Wait();
                                AddStr(DateTime.Now.ToString() + ". func3. 2");
                            })()
                            );
                    })
                    .Wait()
                );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                Task
                    .Run(async () =>
                    {
                        await Task.WhenAll(
                            new Func<Task>(async () =>
                            {
                                await Task.Delay(0); // не передаёт управление вышестоящей функции
                                AddStr(DateTime.Now.ToString() + ". func2. 1");
                                Task.Delay(100).Wait();
                                AddStr(DateTime.Now.ToString() + ". func2. 2");
                            })()
                            ,
                            new Func<Task>(async () =>
                            {
                                await Task.Delay(0);
                                AddStr(DateTime.Now.ToString() + ". func3. 1");
                                Task.Delay(50).Wait();
                                AddStr(DateTime.Now.ToString() + ". func3. 2");
                            })()
                            );
                    })
                    .Wait()
                );
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                Task
                    .Run(async () =>
                    {
                        await Task.WhenAll(
                            new Func<Task>(async () =>
                            {
                                await Task.Delay(1);
                                AddStr(DateTime.Now.ToString() + ". func2. 1");
                                Task.Delay(100).Wait();
                                AddStr(DateTime.Now.ToString() + ". func2. 2");
                            })()
                            ,
                            new Func<Task>(async () =>
                            {
                                await Task.Delay(1);
                                AddStr(DateTime.Now.ToString() + ". func3. 1");
                                Task.Delay(50).Wait();
                                AddStr(DateTime.Now.ToString() + ". func3. 2");
                            })()
                            );
                    })
                    .Wait()
                );
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                Task.WhenAll(
                    Task.Run(() =>
                    {
                        AddStr(DateTime.Now.ToString() + ". func2. 1");
                        Task.Delay(100).Wait();
                        AddStr(DateTime.Now.ToString() + ". func2. 2");
                    })
                    ,
                    Task.Run(() =>
                    {
                        AddStr(DateTime.Now.ToString() + ". func3. 1");
                        Task.Delay(50).Wait();
                        AddStr(DateTime.Now.ToString() + ". func3. 2");
                    })
                    )
                    .Wait()
                );
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RunMyFunc(() =>
                {
                    //Task.Run(() =>
                    //{
                        sub2().Wait();
                        Task.Delay(1000).Wait();
                    //}).Wait();
                }
                );
        }
        private async Task sub2()
        {
            AddStr(DateTime.Now.ToString() + ". sub2. 1");
            sub3();
            AddStr(DateTime.Now.ToString() + ". sub2. 2");
        }
        private async Task sub3()
        {
            AddStr(DateTime.Now.ToString() + ". sub3. 1");
            Task.Delay(100).Wait();
            AddStr(DateTime.Now.ToString() + ". sub3. 2");
        }
    }
}