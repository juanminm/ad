
// This file has been generated by the GUI designer. Do not modify.
namespace CCategoria
{
	public partial class CategoriaView
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action saveAction;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Toolbar toolbar1;

		private global::Gtk.Table table1;

		private global::Gtk.Entry entryNombre;

		private global::Gtk.Label label1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget CCategoria.CategoriaView
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
			this.saveAction = new global::Gtk.Action("saveAction", null, null, "gtk-save");
			w1.Add(this.saveAction, null);
			this.UIManager.InsertActionGroup(w1, 0);
			this.AddAccelGroup(this.UIManager.AccelGroup);
			this.Name = "CCategoria.CategoriaView";
			this.Title = global::Mono.Unix.Catalog.GetString("CategoriaView");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child CCategoria.CategoriaView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString("<ui><toolbar name=\'toolbar1\'><toolitem name=\'saveAction\' action=\'saveAction\'/></t" +
					"oolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.vbox2.Add(this.toolbar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.toolbar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(3)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.entryNombre = new global::Gtk.Entry();
			this.entryNombre.CanFocus = true;
			this.entryNombre.Name = "entryNombre";
			this.entryNombre.IsEditable = true;
			this.entryNombre.InvisibleChar = '•';
			this.table1.Add(this.entryNombre);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.entryNombre]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("label1");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table1]));
			w5.Position = 1;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show();
		}
	}
}
