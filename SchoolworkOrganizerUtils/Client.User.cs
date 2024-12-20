﻿using SchoolworkOrganizerUtils.MessageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SchoolworkOrganizerUtils
{
    public partial class Client
    {
        public User? user { get; private set; }
        private TaskCompletionSource<bool>? loginTcs;
        private TaskCompletionSource<bool>? registerTcs;
        private Timer updateTimer = new Timer(5000);

        public async Task<bool> Login(string username, string password)
        {
            loginTcs = new TaskCompletionSource<bool>();
            Message message = new LoginMessage(username, password);
            await SendMessageAsync(message);

            bool loginSuccess = await loginTcs.Task;
            return loginSuccess;
        }

        public async Task<bool> Register(User user)
        {
            if (registerTcs != null) return false;

            registerTcs = new TaskCompletionSource<bool>();
            Message message = new UserMessage(MessageType.Register, user);
            await SendMessageAsync(message);

            return await registerTcs.Task;
        }

        internal async Task<bool> UpdateUser(User user, string oldUsername)
        {
            if (user == null) return false;

            Message message = new UserMessage(MessageType.UpdateUser, user, oldUsername);
            await SendMessageAsync(message);

            return true;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Checking for updates...");
            CheckForUpdates();
        }

        public void Logout()
        {
            updateTimer.Close();
            user = null;
        }

        private void HandleFetchUser(Message message)
        {
            if (message is not UserMessage) return;
            if (message.Type != MessageType.FetchUser) return;
            UserMessage userMessage = (UserMessage)message;
            user = userMessage.GetUser();
            user.client = this;

            if (loginTcs != null)
            {
                loginTcs.SetResult(true);
                Console.WriteLine("Logged in.");
                loginTcs = null;
            }

            updateTimer.Start();

            updateTimer.Elapsed += OnTimedEvent;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;
        }

        private void HandleFetchUserData(Message message)
        {
            if (user == null) return;
            if (message is not UserDataMessage) return;
            UserDataMessage userDataMessage = (UserDataMessage)message;

            user.Subjects = userDataMessage.GetSubjects(user);
        }

    }
}
