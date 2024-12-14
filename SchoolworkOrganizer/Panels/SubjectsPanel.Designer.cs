namespace SchoolworkOrganizer.Panels
{
    partial class SubjectsPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel4 = new Panel();
            refreshBtn = new Button();
            panel5 = new Panel();
            label3 = new Label();
            cancelBtn = new Button();
            deleteBtn = new Button();
            saveBtn = new Button();
            addBtn = new Button();
            subjectTxtBox = new TextBox();
            subjectLabel = new Label();
            panel8 = new Panel();
            table = new DataGridView();
            Subject = new DataGridViewTextBoxColumn();
            Reviewers = new DataGridViewTextBoxColumn();
            Activities = new DataGridViewTextBoxColumn();
            SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            Controls.Add(panel8);
            Controls.Add(panel4);
            Margin = new Padding(5, 3, 5, 3);
            Size = new Size(1089, 626);
            // 
            // panel4
            // 
            panel4.Controls.Add(refreshBtn);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(cancelBtn);
            panel4.Controls.Add(deleteBtn);
            panel4.Controls.Add(saveBtn);
            panel4.Controls.Add(addBtn);
            panel4.Controls.Add(subjectTxtBox);
            panel4.Controls.Add(subjectLabel);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(252, 626);
            panel4.TabIndex = 0;
            // 
            // refreshBtn
            // 
            refreshBtn.BackColor = Color.FromArgb(52, 63, 82);
            refreshBtn.FlatAppearance.BorderSize = 0;
            refreshBtn.FlatStyle = FlatStyle.Flat;
            refreshBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshBtn.ForeColor = Color.FromArgb(231, 231, 231);
            refreshBtn.Location = new Point(154, 444);
            refreshBtn.Margin = new Padding(4, 3, 4, 3);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(88, 27);
            refreshBtn.TabIndex = 16;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(252, 62);
            panel5.TabIndex = 7;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Roboto", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(252, 62);
            label3.TabIndex = 6;
            label3.Text = "Subjects";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.FromArgb(52, 63, 82);
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.FromArgb(231, 231, 231);
            cancelBtn.Location = new Point(154, 137);
            cancelBtn.Margin = new Padding(4, 3, 4, 3);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(88, 27);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.FromArgb(171, 37, 51);
            deleteBtn.Enabled = false;
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.FlatStyle = FlatStyle.Flat;
            deleteBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deleteBtn.ForeColor = Color.FromArgb(231, 231, 231);
            deleteBtn.Location = new Point(10, 137);
            deleteBtn.Margin = new Padding(4, 3, 4, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(88, 27);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.FromArgb(52, 63, 82);
            saveBtn.Enabled = false;
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.FromArgb(231, 231, 231);
            saveBtn.Location = new Point(154, 104);
            saveBtn.Margin = new Padding(4, 3, 4, 3);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(88, 27);
            saveBtn.TabIndex = 3;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(95, 192, 170);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.FromArgb(231, 231, 231);
            addBtn.Location = new Point(10, 104);
            addBtn.Margin = new Padding(4, 3, 4, 3);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(88, 27);
            addBtn.TabIndex = 2;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // subjectTxtBox
            // 
            subjectTxtBox.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectTxtBox.Location = new Point(104, 69);
            subjectTxtBox.Margin = new Padding(4, 3, 4, 3);
            subjectTxtBox.Name = "subjectTxtBox";
            subjectTxtBox.Size = new Size(137, 22);
            subjectTxtBox.TabIndex = 1;
            // 
            // subjectLabel
            // 
            subjectLabel.AutoSize = true;
            subjectLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectLabel.Location = new Point(7, 73);
            subjectLabel.Margin = new Padding(4, 0, 4, 0);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(80, 15);
            subjectLabel.TabIndex = 0;
            subjectLabel.Text = "Subject Name:";
            // 
            // panel8
            // 
            panel8.Controls.Add(table);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(252, 0);
            panel8.Margin = new Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(12);
            panel8.Size = new Size(837, 626);
            panel8.TabIndex = 16;
            // 
            // table
            // 
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToResizeRows = false;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { Subject, Reviewers, Activities });
            table.Dock = DockStyle.Fill;
            table.Location = new Point(12, 12);
            table.Margin = new Padding(4, 3, 4, 3);
            table.MultiSelect = false;
            table.Name = "table";
            table.ReadOnly = true;
            table.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            table.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            table.Size = new Size(813, 602);
            table.TabIndex = 6;
            // 
            // Subject
            // 
            Subject.HeaderText = "Subject";
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            // 
            // Reviewers
            // 
            Reviewers.HeaderText = "Reviewers";
            Reviewers.Name = "Reviewers";
            Reviewers.ReadOnly = true;
            // 
            // Activities
            // 
            Activities.HeaderText = "Activities";
            Activities.Name = "Activities";
            Activities.ReadOnly = true;
            // 
            // SubjectsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Margin = new Padding(5, 3, 5, 3);
            Name = "SubjectsPanel";
            Text = "Subjects";
            ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subjectTxtBox;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviewers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activities;
        private System.Windows.Forms.Button refreshBtn;
    }
}