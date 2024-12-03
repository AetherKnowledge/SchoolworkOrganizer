using System.Globalization;

namespace SchoolworkOrganizer.Panels
{
    partial class ActivitiesPanel
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
            searchComboBox = new ComboBox();
            panel5 = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            panel4 = new Panel();
            refreshBtn = new Button();
            statusCBox = new ComboBox();
            label2 = new Label();
            selectedFileLabel = new TextBox();
            openFileBtn = new Button();
            editFileBtn = new Button();
            fileLabel = new Label();
            cancelBtn = new Button();
            deleteBtn = new Button();
            saveBtn = new Button();
            addBtn = new Button();
            dueDatePicker = new DateTimePicker();
            label1 = new Label();
            editSubjectCBox = new ComboBox();
            subjectLabel = new Label();
            panel1 = new Panel();
            label3 = new Label();
            reviewerTxtBox = new TextBox();
            reviewerLabel = new Label();
            panel8 = new Panel();
            panel2 = new Panel();
            table = new DataGridView();
            ActivityName = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            FilePath = new DataGridViewButtonColumn();
            DueDate = new DataGridViewTextBoxColumn();
            DaysRemaining = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            subjectCBox = new ComboBox();
            mainPanel.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(panel8);
            mainPanel.Controls.Add(panel4);
            mainPanel.Margin = new Padding(5, 3, 5, 3);
            mainPanel.Size = new Size(1089, 626);
            // 
            // searchComboBox
            // 
            searchComboBox.Dock = DockStyle.Fill;
            searchComboBox.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchComboBox.FormattingEnabled = true;
            searchComboBox.Location = new Point(10, 10);
            searchComboBox.Name = "searchComboBox";
            searchComboBox.Size = new Size(772, 33);
            searchComboBox.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel7);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(792, 50);
            panel5.TabIndex = 14;
            // 
            // panel7
            // 
            panel7.Controls.Add(searchComboBox);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(792, 50);
            panel7.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(692, 0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(100, 50);
            panel6.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(refreshBtn);
            panel4.Controls.Add(statusCBox);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(selectedFileLabel);
            panel4.Controls.Add(openFileBtn);
            panel4.Controls.Add(editFileBtn);
            panel4.Controls.Add(fileLabel);
            panel4.Controls.Add(cancelBtn);
            panel4.Controls.Add(deleteBtn);
            panel4.Controls.Add(saveBtn);
            panel4.Controls.Add(addBtn);
            panel4.Controls.Add(dueDatePicker);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(editSubjectCBox);
            panel4.Controls.Add(subjectLabel);
            panel4.Controls.Add(panel1);
            panel4.Controls.Add(reviewerTxtBox);
            panel4.Controls.Add(reviewerLabel);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(252, 626);
            panel4.TabIndex = 2;
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
            refreshBtn.TabIndex = 26;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // statusCBox
            // 
            statusCBox.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusCBox.FormattingEnabled = true;
            statusCBox.Items.AddRange(new object[] { "Complete", "Incomplete" });
            statusCBox.Location = new Point(107, 160);
            statusCBox.Margin = new Padding(4, 3, 4, 3);
            statusCBox.Name = "statusCBox";
            statusCBox.Size = new Size(134, 23);
            statusCBox.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(61, 160);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 24;
            label2.Text = "Status:";
            // 
            // selectedFileLabel
            // 
            selectedFileLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectedFileLabel.Location = new Point(107, 192);
            selectedFileLabel.Margin = new Padding(4, 3, 4, 3);
            selectedFileLabel.Multiline = true;
            selectedFileLabel.Name = "selectedFileLabel";
            selectedFileLabel.ReadOnly = true;
            selectedFileLabel.Size = new Size(134, 52);
            selectedFileLabel.TabIndex = 23;
            // 
            // openFileBtn
            // 
            openFileBtn.BackColor = Color.FromArgb(52, 63, 82);
            openFileBtn.FlatAppearance.BorderSize = 0;
            openFileBtn.FlatStyle = FlatStyle.Flat;
            openFileBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            openFileBtn.ForeColor = Color.FromArgb(231, 231, 231);
            openFileBtn.Location = new Point(107, 287);
            openFileBtn.Margin = new Padding(4, 3, 4, 3);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(134, 27);
            openFileBtn.TabIndex = 22;
            openFileBtn.Text = "Open File";
            openFileBtn.UseVisualStyleBackColor = false;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // editFileBtn
            // 
            editFileBtn.BackColor = Color.FromArgb(52, 63, 82);
            editFileBtn.FlatAppearance.BorderSize = 0;
            editFileBtn.FlatStyle = FlatStyle.Flat;
            editFileBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editFileBtn.ForeColor = Color.FromArgb(231, 231, 231);
            editFileBtn.Location = new Point(107, 254);
            editFileBtn.Margin = new Padding(4, 3, 4, 3);
            editFileBtn.Name = "editFileBtn";
            editFileBtn.Size = new Size(134, 27);
            editFileBtn.TabIndex = 21;
            editFileBtn.Text = "Edit File";
            editFileBtn.UseVisualStyleBackColor = false;
            editFileBtn.Click += editFileBtn_Click;
            // 
            // fileLabel
            // 
            fileLabel.AutoSize = true;
            fileLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileLabel.Location = new Point(74, 195);
            fileLabel.Margin = new Padding(4, 0, 4, 0);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(27, 15);
            fileLabel.TabIndex = 20;
            fileLabel.Text = "File:";
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.FromArgb(52, 63, 82);
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.FromArgb(231, 231, 231);
            cancelBtn.Location = new Point(154, 374);
            cancelBtn.Margin = new Padding(4, 3, 4, 3);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(88, 27);
            cancelBtn.TabIndex = 19;
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
            deleteBtn.Location = new Point(10, 374);
            deleteBtn.Margin = new Padding(4, 3, 4, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(88, 27);
            deleteBtn.TabIndex = 18;
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
            saveBtn.Location = new Point(154, 340);
            saveBtn.Margin = new Padding(4, 3, 4, 3);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(88, 27);
            saveBtn.TabIndex = 17;
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
            addBtn.Location = new Point(10, 340);
            addBtn.Margin = new Padding(4, 3, 4, 3);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(88, 27);
            addBtn.TabIndex = 16;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // dueDatePicker
            // 
            dueDatePicker.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dueDatePicker.Location = new Point(107, 130);
            dueDatePicker.Margin = new Padding(4, 3, 4, 3);
            dueDatePicker.Name = "dueDatePicker";
            dueDatePicker.Size = new Size(134, 22);
            dueDatePicker.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 130);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 14;
            label1.Text = "Due Date:";
            // 
            // editSubjectCBox
            // 
            editSubjectCBox.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editSubjectCBox.FormattingEnabled = true;
            editSubjectCBox.Location = new Point(107, 99);
            editSubjectCBox.Margin = new Padding(4, 3, 4, 3);
            editSubjectCBox.Name = "editSubjectCBox";
            editSubjectCBox.Size = new Size(134, 23);
            editSubjectCBox.TabIndex = 9;
            // 
            // subjectLabel
            // 
            subjectLabel.AutoSize = true;
            subjectLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectLabel.Location = new Point(18, 103);
            subjectLabel.Margin = new Padding(4, 0, 4, 0);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(80, 15);
            subjectLabel.TabIndex = 8;
            subjectLabel.Text = "Subject Name:";
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(252, 62);
            panel1.TabIndex = 7;
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
            label3.Text = "Activities";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // reviewerTxtBox
            // 
            reviewerTxtBox.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reviewerTxtBox.Location = new Point(107, 69);
            reviewerTxtBox.Margin = new Padding(4, 3, 4, 3);
            reviewerTxtBox.Name = "reviewerTxtBox";
            reviewerTxtBox.Size = new Size(134, 22);
            reviewerTxtBox.TabIndex = 1;
            // 
            // reviewerLabel
            // 
            reviewerLabel.AutoSize = true;
            reviewerLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reviewerLabel.Location = new Point(18, 73);
            reviewerLabel.Margin = new Padding(4, 0, 4, 0);
            reviewerLabel.Name = "reviewerLabel";
            reviewerLabel.Size = new Size(79, 15);
            reviewerLabel.TabIndex = 0;
            reviewerLabel.Text = "Activity Name:";
            // 
            // panel8
            // 
            panel8.Controls.Add(panel2);
            panel8.Controls.Add(panel3);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(252, 0);
            panel8.Margin = new Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(837, 626);
            panel8.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.Controls.Add(table);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 43);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(12);
            panel2.Size = new Size(837, 583);
            panel2.TabIndex = 8;
            // 
            // table
            // 
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToResizeRows = false;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { ActivityName, Subject, FilePath, DueDate, DaysRemaining, Status });
            table.Dock = DockStyle.Fill;
            table.Location = new Point(12, 12);
            table.Margin = new Padding(4, 3, 4, 3);
            table.MultiSelect = false;
            table.Name = "table";
            table.ReadOnly = true;
            table.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            table.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            table.Size = new Size(813, 559);
            table.TabIndex = 6;
            // 
            // ActivityName
            // 
            ActivityName.HeaderText = "Activity";
            ActivityName.Name = "ActivityName";
            ActivityName.ReadOnly = true;
            // 
            // Subject
            // 
            Subject.HeaderText = "Subject";
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            // 
            // FilePath
            // 
            FilePath.HeaderText = "File";
            FilePath.Name = "FilePath";
            FilePath.ReadOnly = true;
            FilePath.Resizable = DataGridViewTriState.True;
            FilePath.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // DueDate
            // 
            DueDate.HeaderText = "Due Date";
            DueDate.Name = "DueDate";
            DueDate.ReadOnly = true;
            // 
            // DaysRemaining
            // 
            DaysRemaining.HeaderText = "Days Remaining";
            DaysRemaining.Name = "DaysRemaining";
            DaysRemaining.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(subjectCBox);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(12);
            panel3.Size = new Size(837, 43);
            panel3.TabIndex = 7;
            // 
            // subjectCBox
            // 
            subjectCBox.Dock = DockStyle.Fill;
            subjectCBox.Font = new Font("Roboto Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectCBox.FormattingEnabled = true;
            subjectCBox.Location = new Point(12, 12);
            subjectCBox.Margin = new Padding(4, 3, 4, 3);
            subjectCBox.Name = "subjectCBox";
            subjectCBox.Size = new Size(813, 26);
            subjectCBox.TabIndex = 0;
            subjectCBox.SelectedIndexChanged += subjectCBox_SelectedIndexChanged;
            // 
            // ActivitiesPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Margin = new Padding(5, 3, 5, 3);
            Name = "ActivitiesPanel";
            Text = "Activities";
            mainPanel.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox editSubjectCBox;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reviewerTxtBox;
        private System.Windows.Forms.Label reviewerLabel;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox subjectCBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.TextBox selectedFileLabel;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Button editFileBtn;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ComboBox statusCBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewButtonColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysRemaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button refreshBtn;
    }
}