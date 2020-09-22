using AsyncWindowsApplication.Models;
using AsyncWindowsApplication.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncWindowsApplication
{
    public partial class Form1 : Form
    {
        private readonly IUserRepository repository;

        public Form1(IUserRepository repository)
        {
            InitializeComponent();
            this.repository = repository;

            this.repository.NotifyClientErrorEvent += (sender, eventArgs) =>
                MessageBox.Show(eventArgs.GetException().Message);

            this.repository.NotifyInsertEvent += (sender, args) =>
                MessageBox.Show($"User with {args.Id} id was created");

            Refresh();
        }

        private async void refreshBtn_Click(object sender, EventArgs e) => await Refresh();

        private async void addBtn_Click(object sender, EventArgs e)
        {
            await this.repository.Create(new User
            {
                Name = this.nameTextBox.Text,
                Age = Convert.ToInt32(this.ageTextBox.Text)
            });

            await Refresh();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }






        private async Task Refresh()
        {
            var users = await this.repository.Get();
            this.userListBox.Items.Clear();
            this.userListBox.Items.AddRange(users.Select(u => u.ToString()).ToArray());
        }
    }
}
