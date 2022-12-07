using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitAddinAcademy
{
    public partial class frmToDo : Form
    {
        string ToDoFilePath = "";
        BindingList<ToDoData> todoDataList = new BindingList<ToDoData>();
        ToDoData currentEdit;
        public frmToDo(string filePath)
        {
            InitializeComponent();
            
            lbl_FileName.Text = Path.GetFileName(filePath);

            string curPath = Path.GetDirectoryName(filePath);
            string curFileName = Path.GetFileNameWithoutExtension(filePath) + "_ToDo.txt";

            ToDoFilePath = curPath + "\\" + curFileName;

            readTodoFile();
        }

        private void readTodoFile()
        {
            if(File.Exists(ToDoFilePath))
            {
                int counter = 0;
                string[] strings = File.ReadAllLines(ToDoFilePath);

                foreach( string line in strings )
                {
                    string[] todoData = ToDoData.ParseDisplayString(line);

                    ToDoData curTodo = new ToDoData(counter + 1, todoData[0], todoData[1]);
                    todoDataList.Add(curTodo);
                    counter++;
                }
            }
            ShowData();
        }

        private void ShowData()
        {
            lbx_ToDo.DataSource = null;
            lbx_ToDo.DataSource = todoDataList;
            lbx_ToDo.DisplayMember = "Display";
        }

        private void AddTodoItem(string todoText)
        {
            ToDoData curTodo = new ToDoData(todoDataList.Count + 1, todoText, "To Do");
            todoDataList.Add(curTodo);

            WriteTodoFile();
        }

        private void RemoveItem(ToDoData curTodo)
        {
            todoDataList.Remove(curTodo);
            ReorderTodoItems();
            WriteTodoFile();
        }

        private void ReorderTodoItems()
        {
            for (int i = 0; i < todoDataList.Count; i++)
            {
                todoDataList[i].PositionNumber = i + 1;
                todoDataList[i].UpdateDisplayString();
            }
        }

        private void WriteTodoFile()
        {
            using(StreamWriter writer = File.CreateText(ToDoFilePath))
            {
                foreach(ToDoData curTodo in lbx_ToDo.Items)
                {
                    curTodo.UpdateDisplayString();
                    writer.WriteLine(curTodo.Display);
                }
            }
            ShowData();
        }

        private void btn_AddEdit_Click(object sender, EventArgs e)
        {
            if (currentEdit == null)
            {
                if (tbx_AddEdit.Text != "")
                {
                    AddTodoItem(tbx_AddEdit.Text);
                }
            }
            else
            {
                CompleteEditingItem();
            }

            tbx_AddEdit.Text = "";
            
        }

        private void CompleteEditingItem()
        {
            foreach (ToDoData toDo in todoDataList)
            {
                if(toDo == currentEdit)
                {
                    toDo.Text = tbx_AddEdit.Text;
                }
            }

            currentEdit = null;
            lbl_AddNewItems.Text = "Add Item";
            btn_AddEdit.Text = "Add Item";

            WriteTodoFile();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lbx_ToDo.SelectedItems != null)
            {
                ToDoData curTodo = lbx_ToDo.SelectedItem as ToDoData;
                RemoveItem(curTodo);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (lbx_ToDo.SelectedItems != null)
            {
                ToDoData curTodo = lbx_ToDo.SelectedItem as ToDoData;
                StartEditingItem(curTodo);

            }
        }

        private void StartEditingItem(ToDoData curTodo)
        {
            currentEdit = curTodo;
            lbl_AddNewItems.Text = "Update Item";
            btn_AddEdit.Text = "Update Item";
            tbx_AddEdit.Text = curTodo.Text;

        }

        private void lbx_ToDo_DoubleClick(object sender, EventArgs e)
        {
            if(lbx_ToDo.SelectedItems != null)
            {
                ToDoData todo = lbx_ToDo.SelectedItem as ToDoData;
                FinishItem(todo);

            }
        }

        private void FinishItem(ToDoData todo)
        {
            todo.Status = "Complete";
            WriteTodoFile();
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (lbx_ToDo.SelectedItem != null)
            {
                ToDoData todo = lbx_ToDo.SelectedItem as ToDoData;
                MoveItemUp(todo);
            }
        }

        private void MoveItemUp(ToDoData todo)
        {
            for (int i = 0; i < todoDataList.Count; i++)
            {
                if (todoDataList[i] == todo)
                {
                    if (i != 0)
                    {
                        todoDataList.RemoveAt(i);
                        todoDataList.Insert(i - 1, todo);
                        ReorderTodoItems();
                    }
                }
            }
            WriteTodoFile();
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (lbx_ToDo.SelectedItem != null)
            {
                ToDoData todo = lbx_ToDo.SelectedItem as ToDoData;
                MoveItemDown(todo);
            }
        }

        private void MoveItemDown(ToDoData todo)
        {
            for (int i = 0; i < todoDataList.Count; i++)
            {
                if (todoDataList[i] == todo)
                {
                    if (i < todoDataList.Count -1)
                    {
                        todoDataList.RemoveAt(i);
                        todoDataList.Insert(i + 1, todo);
                        ReorderTodoItems();
                    }
                }
            }
            WriteTodoFile();
        }
    }
}
