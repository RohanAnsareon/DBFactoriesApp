using AsyncWindowsApplication.Models;
using AsyncWindowsApplication.Repositories;
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
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;


        public Form1(IUserRepository repository,IGroupRepository repository1)
        {
            InitializeComponent();
            this.userRepository = repository;
            this.userRepository.NotifyClientErrorEvent += (sender, eventArgs) =>
                MessageBox.Show(eventArgs.GetException().Message);

            this.groupRepository = repository1;
            this.groupRepository.NotifyClientErrorEvent += (sender, eventArgs) =>
                MessageBox.Show(eventArgs.GetException().Message);

            Refresh();
        }

        private async void refreshBtn_Click(object sender, EventArgs e) => await Refresh();

        private async void addBtn_Click(object sender, EventArgs e)
        {
            var id = await this.userRepository.Create(new User
            {
                Name = this.nameTextBox.Text,
                Age = Convert.ToInt32(this.ageTextBox.Text),
                GroupId = Convert.ToInt32(this.groupTextBox.Text)

            }
                );
         
            if (id != 0) MessageBox.Show($"User with {id} id was created");

            Refresh();
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(userIdTxtBox.Text);
            if (id>0)
            {
                await this.userRepository.Delete(id);
            }
            Refresh();
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            var user = new User{ Id = Convert.ToInt32(userIdTxtBox.Text), Age = Convert.ToInt32(ageTextBox.Text), Name = nameTextBox.Text };
          
                await this.userRepository.Update(user);
            
            Refresh();
        }


        private async Task Refresh()
        {
            var users = await this.userRepository.Get();
            this.userListBox.Items.Clear();
            this.userListBox.Items.AddRange(users.Select(u => u.ToString()).ToArray());

            var groups = await this.groupRepository.Get();
            this.GroupListBox.Items.Clear();
            this.GroupListBox.Items.AddRange(groups.Select(g => g.ToString()).ToArray());

        }

        private async  void GroupUpaddBtn_Click(object sender, EventArgs e)
        {
            var id = await this.groupRepository.Create(new Group
            {
                Title = GroupTitleTextBox.Text
            }) ;

            if (id != 0) MessageBox.Show($"Group with {id} id was created");

            Refresh();
        }

        private async void GroupUpdateBtn_Click(object sender, EventArgs e)
        {
            var group = new Group { 
                Id = Convert.ToInt32(GroupIdTextBox.Text),
                Title = GroupTitleTextBox.Text };

            await this.groupRepository.Update(group);

            Refresh();
        }

        private async  void GroupDeleteBtn_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(GroupIdTextBox.Text);
            if (id > 0)
            {
                await this.groupRepository.Delete(id);
            }
            Refresh();
        }
    }
}
