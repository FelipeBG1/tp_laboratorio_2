namespace Formulario
{
    partial class FormLibro
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
            this.TipoBox = new System.Windows.Forms.ComboBox();
            this.EditorialBox = new System.Windows.Forms.TextBox();
            this.TituloBox = new System.Windows.Forms.TextBox();
            this.PrecioBox = new System.Windows.Forms.TextBox();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCncelar = new System.Windows.Forms.Button();
            this.CaracteristicaBox = new System.Windows.Forms.ComboBox();
            this.lblCaracteristica = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TipoBox
            // 
            this.TipoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoBox.FormattingEnabled = true;
            this.TipoBox.Items.AddRange(new object[] {
            "Cuento",
            "Novela",
            "Investigacion"});
            this.TipoBox.Location = new System.Drawing.Point(51, 224);
            this.TipoBox.Name = "TipoBox";
            this.TipoBox.Size = new System.Drawing.Size(256, 28);
            this.TipoBox.TabIndex = 1;
            this.TipoBox.SelectedIndexChanged += new System.EventHandler(this.TipoBox_SelectedIndexChanged);
            // 
            // EditorialBox
            // 
            this.EditorialBox.Location = new System.Drawing.Point(50, 66);
            this.EditorialBox.Name = "EditorialBox";
            this.EditorialBox.Size = new System.Drawing.Size(256, 26);
            this.EditorialBox.TabIndex = 2;
            // 
            // TituloBox
            // 
            this.TituloBox.Location = new System.Drawing.Point(50, 149);
            this.TituloBox.Name = "TituloBox";
            this.TituloBox.Size = new System.Drawing.Size(256, 26);
            this.TituloBox.TabIndex = 3;
            // 
            // PrecioBox
            // 
            this.PrecioBox.Location = new System.Drawing.Point(50, 299);
            this.PrecioBox.Name = "PrecioBox";
            this.PrecioBox.Size = new System.Drawing.Size(256, 26);
            this.PrecioBox.TabIndex = 4;
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditorial.Location = new System.Drawing.Point(46, 35);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(91, 26);
            this.lblEditorial.TabIndex = 5;
            this.lblEditorial.Text = "Editorial";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(46, 115);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(64, 26);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Título";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(46, 190);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(53, 26);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(46, 266);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(74, 26);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(27, 424);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(126, 49);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCncelar
            // 
            this.btnCncelar.Location = new System.Drawing.Point(241, 424);
            this.btnCncelar.Name = "btnCncelar";
            this.btnCncelar.Size = new System.Drawing.Size(126, 49);
            this.btnCncelar.TabIndex = 10;
            this.btnCncelar.Text = "Cancelar";
            this.btnCncelar.UseVisualStyleBackColor = true;
            this.btnCncelar.Click += new System.EventHandler(this.btnCncelar_Click);
            // 
            // CaracteristicaBox
            // 
            this.CaracteristicaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CaracteristicaBox.FormattingEnabled = true;
            this.CaracteristicaBox.Location = new System.Drawing.Point(50, 374);
            this.CaracteristicaBox.Name = "CaracteristicaBox";
            this.CaracteristicaBox.Size = new System.Drawing.Size(256, 28);
            this.CaracteristicaBox.TabIndex = 11;
            // 
            // lblCaracteristica
            // 
            this.lblCaracteristica.AutoSize = true;
            this.lblCaracteristica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaracteristica.Location = new System.Drawing.Point(44, 341);
            this.lblCaracteristica.Name = "lblCaracteristica";
            this.lblCaracteristica.Size = new System.Drawing.Size(145, 26);
            this.lblCaracteristica.TabIndex = 12;
            this.lblCaracteristica.Text = "Caracteristica";
            // 
            // FormLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(391, 485);
            this.Controls.Add(this.lblCaracteristica);
            this.Controls.Add(this.CaracteristicaBox);
            this.Controls.Add(this.btnCncelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblEditorial);
            this.Controls.Add(this.PrecioBox);
            this.Controls.Add(this.TituloBox);
            this.Controls.Add(this.EditorialBox);
            this.Controls.Add(this.TipoBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormLibro";
            this.Text = "Agregar Stock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TipoBox;
        private System.Windows.Forms.TextBox EditorialBox;
        private System.Windows.Forms.TextBox TituloBox;
        private System.Windows.Forms.TextBox PrecioBox;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCncelar;
        private System.Windows.Forms.ComboBox CaracteristicaBox;
        private System.Windows.Forms.Label lblCaracteristica;
    }
}