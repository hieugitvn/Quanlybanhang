using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Diagnostics.Eventing.Reader;

namespace Botbanhang
{
    public partial class Bot : Form
    {
        public TelegramBotClient botClient;
        int logCounter = 0;
        public long chatId = 6233179764;

        void AddLog(string msg)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke((MethodInvoker)delegate ()
                {
                    AddLog(msg);
                });
            }
            else
            {
                logCounter++;
                if (logCounter > 100)
                {
                    textBox1.Clear();
                    logCounter = 0;
                }
                textBox1.AppendText(msg + "\r\n");
            }
        }

        public Bot()
        {
            InitializeComponent();
            // Thằng QuanLyBanHanglv1_bot
            string token = "5897322546:AAER81g3LxIirw1j3dX9Z8IUEQ0t_ohu9C4";

            //Console.WriteLine("my token=" + token);

            botClient = new TelegramBotClient(token);  // Tạo 1 thằng bot 

            /*using CancellationTokenSource cts = new();
            mượn của thầy mà nó bắt phải c# 8.0.Em vào chỗ sửa lên thì hiện automatically select based on framework version không sửa được,thử sau vậy*/
            CancellationTokenSource cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };


            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,  //hàm xử lý khi có người chát đến
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            Task<User> me = botClient.GetMeAsync();
            AddLog($"Đã khởi động bot: @{me.Result.Username}");

            //async lập trình bất đồng bộ
            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                // Only process Message updates: https://core.telegram.org/bots/api#message
                bool ok = false;

                //kdl? biến <=> biến đó có thể nhận NULL

                Telegram.Bot.Types.Message message = null;

                // update.Message là người dùng nhắn 1 tin nhắn mới tới bot
                if (update.Message != null)
                {
                    message = update.Message;
                    ok = true;
                }

                if (update.EditedMessage != null)
                {
                    message = update.EditedMessage;
                    ok = true;
                }

                if (!ok || message == null) return; //thoát ngay

                string messageText = message.Text;
                if (messageText == null) return;  //ko chơi với null

                var chatId = message.Chat.Id;  //id của người chát với bot

                AddLog($"{chatId}: {messageText}");  //show lên để xem
                string reply = "";  //đây là text trả lời

                string s2 = messageText.ToLower();


                //Đến phần lắp code chạy mấy cái gọi data ra hay kêu phản hồi dựa theo các điều kiện mình đưa ra 





                //code phản hồi mấy cái mình cần với thích đến đây thôi


                AddLog(reply); //show log to see

                // Echo received message text
                Telegram.Bot.Types.Message sentMessage = await botClient.SendTextMessageAsync(
                       chatId: chatId,
                       text: reply,
                       parseMode: ParseMode.Html  //bổ xung ngày 25.5.2023
                      );

                //đọc thêm về ParseMode.Html tại: https://core.telegram.org/bots/api#html-style
            }


            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                string ErrorMessage;

                if (exception is ApiRequestException apiRequestException)
                {
                    ErrorMessage = $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}";
                }
                else
                {
                    ErrorMessage = exception.ToString();
                }

                AddLog(ErrorMessage);
                return Task.CompletedTask;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
