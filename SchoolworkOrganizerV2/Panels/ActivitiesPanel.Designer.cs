using System.Globalization;

namespace SchoolworkOrganizerV2.Panels
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
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.statusCBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedFileLabel = new System.Windows.Forms.TextBox();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.editFileBtn = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.editSubjectCBox = new System.Windows.Forms.ComboBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.reviewerTxtBox = new System.Windows.Forms.TextBox();
            this.reviewerLabel = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.table = new System.Windows.Forms.DataGridView();
            this.ActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.subjectCBox = new System.Windows.Forms.ComboBox();
            this.mainPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panel8);
            this.mainPanel.Controls.Add(this.panel4);
            this.mainPanel.Size = new System.Drawing.Size(780, 420);
            // 
            // searchComboBox
            // 
            this.searchComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchComboBox.FormattingEnabled = true;
            this.searchComboBox.Location = new System.Drawing.Point(10, 10);
            this.searchComboBox.Name = "searchComboBox";
            this.searchComboBox.Size = new System.Drawing.Size(772, 33);
            this.searchComboBox.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(792, 50);
            this.panel5.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.searchComboBox);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(10);
            this.panel7.Size = new System.Drawing.Size(792, 50);
            this.panel7.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(692, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(100, 50);
            this.panel6.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.refreshBtn);
            this.panel4.Controls.Add(this.statusCBox);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.selectedFileLabel);
            this.panel4.Controls.Add(this.openFileBtn);
            this.panel4.Controls.Add(this.editFileBtn);
            this.panel4.Controls.Add(this.fileLabel);
            this.panel4.Controls.Add(this.cancelBtn);
            this.panel4.Controls.Add(this.deleteBtn);
            this.panel4.Controls.Add(this.saveBtn);
            this.panel4.Controls.Add(this.addBtn);
            this.panel4.Controls.Add(this.dueDatePicker);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.editSubjectCBox);
            this.panel4.Controls.Add(this.subjectLabel);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.reviewerTxtBox);
            this.panel4.Controls.Add(this.reviewerLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(216, 420);
            this.panel4.TabIndex = 2;
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.refreshBtn.Location = new System.Drawing.Point(132, 385);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 26;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // statusCBox
            // 
            this.statusCBox.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCBox.FormattingEnabled = true;
            this.statusCBox.Items.AddRange(new object[] {
            "Complete",
            "Incomplete"});
            this.statusCBox.Location = new System.Drawing.Point(92, 139);
            this.statusCBox.Name = "statusCBox";
            this.statusCBox.Size = new System.Drawing.Size(115, 23);
            this.statusCBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Status:";
            // 
            // selectedFileLabel
            // 
            this.selectedFileLabel.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedFileLabel.Location = new System.Drawing.Point(92, 166);
            this.selectedFileLabel.Multiline = true;
            this.selectedFileLabel.Name = "selectedFileLabel";
            this.selectedFileLabel.ReadOnly = true;
            this.selectedFileLabel.Size = new System.Drawing.Size(115, 46);
            this.selectedFileLabel.TabIndex = 23;
            // 
            // openFileBtn
            // 
            this.openFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.openFileBtn.FlatAppearance.BorderSize = 0;
            this.openFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileBtn.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.openFileBtn.Location = new System.Drawing.Point(92, 249);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(115, 23);
            this.openFileBtn.TabIndex = 22;
            this.openFileBtn.Text = "Open File";
            this.openFileBtn.UseVisualStyleBackColor = false;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // editFileBtn
            // 
            this.editFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.editFileBtn.FlatAppearance.BorderSize = 0;
            this.editFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editFileBtn.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFileBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.editFileBtn.Location = new System.Drawing.Point(92, 220);
            this.editFileBtn.Name = "editFileBtn";
            this.editFileBtn.Size = new System.Drawing.Size(115, 23);
            this.editFileBtn.TabIndex = 21;
            this.editFileBtn.Text = "Edit File";
            this.editFileBtn.UseVisualStyleBackColor = false;
            this.editFileBtn.Click += new System.EventHandler(this.editFileBtn_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.Location = new System.Drawing.Point(63, 169);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(27, 15);
            this.fileLabel.TabIndex = 20;
            this.fileLabel.Text = "File:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.cancelBtn.Location = new System.Drawing.Point(132, 324);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.deleteBtn.Enabled = false;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.deleteBtn.Location = new System.Drawing.Point(9, 324);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 18;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.saveBtn.Enabled = false;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.saveBtn.Location = new System.Drawing.Point(132, 295);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(192)))), ((int)(((byte)(170)))));
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.addBtn.Location = new System.Drawing.Point(9, 295);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 16;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dueDatePicker.Location = new System.Drawing.Point(92, 113);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(115, 22);
            this.dueDatePicker.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Due Date:";
            // 
            // editSubjectCBox
            // 
            this.editSubjectCBox.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSubjectCBox.FormattingEnabled = true;
            this.editSubjectCBox.Location = new System.Drawing.Point(92, 86);
            this.editSubjectCBox.Name = "editSubjectCBox";
            this.editSubjectCBox.Size = new System.Drawing.Size(115, 23);
            this.editSubjectCBox.TabIndex = 9;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLabel.Location = new System.Drawing.Point(15, 89);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(80, 15);
            this.subjectLabel.TabIndex = 8;
            this.subjectLabel.Text = "Subject Name:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 54);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 54);
            this.label3.TabIndex = 6;
            this.label3.Text = "Activities";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reviewerTxtBox
            // 
            this.reviewerTxtBox.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewerTxtBox.Location = new System.Drawing.Point(92, 60);
            this.reviewerTxtBox.Name = "reviewerTxtBox";
            this.reviewerTxtBox.Size = new System.Drawing.Size(115, 22);
            this.reviewerTxtBox.TabIndex = 1;
            // 
            // reviewerLabel
            // 
            this.reviewerLabel.AutoSize = true;
            this.reviewerLabel.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewerLabel.Location = new System.Drawing.Point(15, 63);
            this.reviewerLabel.Name = "reviewerLabel";
            this.reviewerLabel.Size = new System.Drawing.Size(79, 15);
            this.reviewerLabel.TabIndex = 0;
            this.reviewerLabel.Text = "Activity Name:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel2);
            this.panel8.Controls.Add(this.panel3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(216, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(564, 420);
            this.panel8.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.table);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(564, 383);
            this.panel2.TabIndex = 8;
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeRows = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActivityName,
            this.Subject,
            this.FilePath,
            this.DueDate,
            this.DaysRemaining,
            this.Status});
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(10, 10);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.table.Size = new System.Drawing.Size(544, 363);
            this.table.TabIndex = 6;
            // 
            // ActivityName
            // 
            this.ActivityName.HeaderText = "Activity";
            this.ActivityName.Name = "ActivityName";
            this.ActivityName.ReadOnly = true;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            // 
            // FilePath
            // 
            this.FilePath.HeaderText = "File";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            // 
            // DaysRemaining
            // 
            this.DaysRemaining.HeaderText = "Days Remaining";
            this.DaysRemaining.Name = "DaysRemaining";
            this.DaysRemaining.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.subjectCBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(564, 37);
            this.panel3.TabIndex = 7;
            // 
            // subjectCBox
            // 
            this.subjectCBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectCBox.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectCBox.FormattingEnabled = true;
            this.subjectCBox.Location = new System.Drawing.Point(10, 10);
            this.subjectCBox.Name = "subjectCBox";
            this.subjectCBox.Size = new System.Drawing.Size(544, 26);
            this.subjectCBox.TabIndex = 0;
            this.subjectCBox.SelectedIndexChanged += new System.EventHandler(this.subjectCBox_SelectedIndexChanged);
            // 
            // ActivitiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 480);
            this.Name = "ActivitiesPanel";
            this.Text = "Activities";
            this.mainPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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