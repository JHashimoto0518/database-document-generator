using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI {
	public partial class CustomizeForm : Form {
		
		public CustomizeForm() {
			InitializeComponent();

			this.KeyPreview = true;
			this.KeyDown += new KeyEventHandler(CustomizeForm_KeyDown);

			_OKButton.Click += new EventHandler(_OKButton_Click);
			_closeButton.Click += new EventHandler(_closeButton_Click);
			_moveUpButton.Click += new EventHandler(_moveUpButton_Click);
			
			_dataGridView.AllowUserToAddRows = false;
			_dataGridView.AllowUserToDeleteRows = false;
			_dataGridView.AllowUserToOrderColumns = true;
			_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			_dataGridView.DataSource = new BindingSource();
		}

		private void _moveUpButton_Click(object sender, EventArgs e) {
			BindingSource bindingSource = _dataGridView.DataSource as BindingSource;
			bindingSource.SuspendBinding();

			DataTable dt = bindingSource.DataSource as DataTable;
			int i = _dataGridView.SelectedRows[0].Index;

			// TODO:CloneÇé¿ëï
			DatabaseConvert.Data.Entity.TableRow row = dt.NewRow() as DatabaseConvert.Data.Entity.TableRow;
			row.ItemArray = dt.Rows[i].ItemArray;
			row.Columns = (dt.Rows[i] as DatabaseConvert.Data.Entity.TableRow).Columns;
			dt.Rows.RemoveAt(i);
			dt.Rows.InsertAt(row, i - 1);

			bindingSource.ResumeBinding();
		}

		private void CustomizeForm_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.Escape:
					_closeButton.PerformClick();
					break;
				default:
					break;
			}
		}

		private void _closeButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void _OKButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		public void Initialize(DataTable dt) {
			(_dataGridView.DataSource as BindingSource).DataSource = dt;
			_dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			_dataGridView.Columns[0].HeaderText = "èoóÕ";
		}
	}
}