namespace RevitAddinAcademy
{
    partial class frmToDo
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
            this.lbl_ToDoItems = new System.Windows.Forms.Label();
            this.lbl_AddNewItems = new System.Windows.Forms.Label();
            this.lbx_ToDo = new System.Windows.Forms.ListBox();
            this.tbx_AddEdit = new System.Windows.Forms.TextBox();
            this.btn_AddEdit = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.lbl_CurrentFile = new System.Windows.Forms.Label();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ToDoItems
            // 
            this.lbl_ToDoItems.AutoSize = true;
            this.lbl_ToDoItems.Location = new System.Drawing.Point(12, 9);
            this.lbl_ToDoItems.Name = "lbl_ToDoItems";
            this.lbl_ToDoItems.Size = new System.Drawing.Size(77, 16);
            this.lbl_ToDoItems.TabIndex = 0;
            this.lbl_ToDoItems.Text = "ToDo Items";
            // 
            // lbl_AddNewItems
            // 
            this.lbl_AddNewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_AddNewItems.AutoSize = true;
            this.lbl_AddNewItems.Location = new System.Drawing.Point(373, 9);
            this.lbl_AddNewItems.Name = "lbl_AddNewItems";
            this.lbl_AddNewItems.Size = new System.Drawing.Size(77, 16);
            this.lbl_AddNewItems.TabIndex = 1;
            this.lbl_AddNewItems.Text = "ToDo Items";
            // 
            // lbx_ToDo
            // 
            this.lbx_ToDo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbx_ToDo.FormattingEnabled = true;
            this.lbx_ToDo.ItemHeight = 16;
            this.lbx_ToDo.Location = new System.Drawing.Point(12, 28);
            this.lbx_ToDo.Name = "lbx_ToDo";
            this.lbx_ToDo.Size = new System.Drawing.Size(344, 580);
            this.lbx_ToDo.TabIndex = 2;
            this.lbx_ToDo.DoubleClick += new System.EventHandler(this.lbx_ToDo_DoubleClick);
            // 
            // tbx_AddEdit
            // 
            this.tbx_AddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_AddEdit.Location = new System.Drawing.Point(376, 28);
            this.tbx_AddEdit.Name = "tbx_AddEdit";
            this.tbx_AddEdit.Size = new System.Drawing.Size(332, 22);
            this.tbx_AddEdit.TabIndex = 3;
            // 
            // btn_AddEdit
            // 
            this.btn_AddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddEdit.Location = new System.Drawing.Point(376, 56);
            this.btn_AddEdit.Name = "btn_AddEdit";
            this.btn_AddEdit.Size = new System.Drawing.Size(119, 23);
            this.btn_AddEdit.TabIndex = 4;
            this.btn_AddEdit.Text = "Add Item";
            this.btn_AddEdit.UseVisualStyleBackColor = true;
            this.btn_AddEdit.Click += new System.EventHandler(this.btn_AddEdit_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Edit.Location = new System.Drawing.Point(376, 142);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(119, 23);
            this.btn_Edit.TabIndex = 5;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.Location = new System.Drawing.Point(376, 171);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(119, 23);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Up.Location = new System.Drawing.Point(378, 414);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(75, 23);
            this.btn_Up.TabIndex = 6;
            this.btn_Up.Text = "Up";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Down.Location = new System.Drawing.Point(378, 443);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(75, 23);
            this.btn_Down.TabIndex = 6;
            this.btn_Down.Text = "Down";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // lbl_CurrentFile
            // 
            this.lbl_CurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CurrentFile.AutoSize = true;
            this.lbl_CurrentFile.Location = new System.Drawing.Point(374, 592);
            this.lbl_CurrentFile.Name = "lbl_CurrentFile";
            this.lbl_CurrentFile.Size = new System.Drawing.Size(77, 16);
            this.lbl_CurrentFile.TabIndex = 7;
            this.lbl_CurrentFile.Text = "Current File:";
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Location = new System.Drawing.Point(374, 608);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(121, 16);
            this.lbl_FileName.TabIndex = 7;
            this.lbl_FileName.Text = "Name of current file";
            // 
            // frmToDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 641);
            this.Controls.Add(this.lbl_FileName);
            this.Controls.Add(this.lbl_CurrentFile);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_AddEdit);
            this.Controls.Add(this.tbx_AddEdit);
            this.Controls.Add(this.lbx_ToDo);
            this.Controls.Add(this.lbl_AddNewItems);
            this.Controls.Add(this.lbl_ToDoItems);
            this.Name = "frmToDo";
            this.Text = "Revit ToDo Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ToDoItems;
        private System.Windows.Forms.Label lbl_AddNewItems;
        private System.Windows.Forms.ListBox lbx_ToDo;
        private System.Windows.Forms.TextBox tbx_AddEdit;
        private System.Windows.Forms.Button btn_AddEdit;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Label lbl_CurrentFile;
        private System.Windows.Forms.Label lbl_FileName;
    }
}