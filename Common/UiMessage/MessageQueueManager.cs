using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Common.CustomControl;

namespace Common.UiMessage
{
    public class MessageQueueManager
    {
        public static readonly MessageQueueManager Instance = new MessageQueueManager();

        private MessageQueueManager()
        {
            _messageQueue = new Queue<MessageItem>();

            ShowMessageTask = Task.Run(async () => { await ShowMessageAsync(); });

            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine($@"{ShowMessageTask.Status}");
            //        await Task.Delay(500);
            //    }
            //});
        }


        private readonly Queue<MessageItem> _messageQueue;
        public Task ShowMessageTask { get; private set; }

        private async Task ShowMessageAsync()
        {
            Console.WriteLine($@"ShowMessageAsync starts, messages={_messageQueue.Count}");
            while (_messageQueue.Count > 0)
            {
                MessageItem msgItem = _messageQueue.Dequeue();

                MsgBoxView msgBoxView = null;
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    msgBoxView = new MsgBoxView()
                    {
                        DataContext = new MsgBoxViewModel(msgItem.Message, msgItem.MessageType)
                    };
                    msgBoxView.Show();
                }));

                await Task.Delay(3000);

                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    msgBoxView?.Close();
                }));
            }
        }

        private void StartShowMessage()
        {
            if (ShowMessageTask.IsCompleted)
            {
                Console.WriteLine(@"_showMessageTask is completed, restart it!!!");
                ShowMessageTask = Task.Run(async () => { await ShowMessageAsync(); });
            }
        }

        public void AddInfo(string message)
        {
            _messageQueue.Enqueue(new MessageItem(message, MessageType.Info));
            StartShowMessage();
        }

        public void AddWarning(string message)
        {
            _messageQueue.Enqueue(new MessageItem(message, MessageType.Warning));
            StartShowMessage();
        }

        public void AddError(string message)
        {
            _messageQueue.Enqueue(new MessageItem(message, MessageType.Error));
            StartShowMessage();
        }
    }
}
