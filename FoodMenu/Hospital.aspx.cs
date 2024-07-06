using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodMenu
{
    public partial class Hospital : System.Web.UI.Page
    {
        private List<EntDoctor> _doctors;
        private List<EntSexo> _sexos;
        private List<EntIntervencion> _intervenciones;
        private List<EntTurno> _turnos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _doctors = new List<EntDoctor>();
                _sexos = new List<EntSexo>
                {
                    new EntSexo { Id_Sexo = 1, Nombre_Sexo = "Male" },
                    new EntSexo { Id_Sexo = 2, Nombre_Sexo = "Female" },
                    new EntSexo { Id_Sexo = 3, Nombre_Sexo = "Other" }
                };

                _intervenciones = new List<EntIntervencion>
                {
                    new EntIntervencion { Id_Intervencion = 1, Nombre_Intervencion = "Intervention 1" },
                    new EntIntervencion { Id_Intervencion = 2, Nombre_Intervencion = "Intervention 2" },
                    new EntIntervencion { Id_Intervencion = 3, Nombre_Intervencion = "Intervention 3" }
                };

                _turnos = new List<EntTurno>
                {
                    new EntTurno { Id_Turno = 1, Nombre_Turno = "Morning" },
                    new EntTurno { Id_Turno = 2, Nombre_Turno = "Afternoon" },
                    new EntTurno { Id_Turno = 3, Nombre_Turno = "Night" }
                };

                GenerateFakeDoctors(10);
                LlenargvDoctores();
                LlenarchkTurno();
                LlenarrbIntervencion();
                LlenarddlSexo();
            }
        }

        public void LlenarddlSexo()
        {
            try
            {
                DropDownList ddlSexo = (DropDownList)gvDoctores.FooterRow.FindControl("ddlSexoFT");
                ddlSexo.DataSource = _sexos;
                ddlSexo.DataTextField = "Nombre_Sexo";
                ddlSexo.DataValueField = "Id_Sexo";
                ddlSexo.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LlenarrbIntervencion()
        {
            try
            {
                RadioButtonList rbinter = (RadioButtonList)gvDoctores.FooterRow.FindControl("rbInterFT");
                rbinter.DataSource = _intervenciones;
                rbinter.DataTextField = "Nombre_Intervencion";
                rbinter.DataValueField = "Id_Intervencion";
                rbinter.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LlenarchkTurno()
        {
            try
            {
                CheckBoxList chkTurno = (CheckBoxList)gvDoctores.FooterRow.FindControl("chkTurnoFT");
                chkTurno.DataSource = _turnos;
                chkTurno.DataTextField = "Nombre_Turno";
                chkTurno.DataValueField = "Id_Turno";
                chkTurno.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region gvDoctores

        public void LlenargvDoctores()
        {
            gvDoctores.DataSource = GetDoctors();
            gvDoctores.DataBind();
        }

        protected void gvDoctores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvDoctores.EditIndex = e.NewEditIndex; // cambiar a modo editar
                LlenargvDoctores(); //recargar el gv
                DropDownList ddlSexo = (DropDownList)gvDoctores.Rows[e.NewEditIndex].FindControl("ddlSexoEIT");
                ddlSexo.DataSource = _sexos;
                ddlSexo.DataTextField = "Nombre_Sexo";
                ddlSexo.DataValueField = "Id_Sexo";
                ddlSexo.DataBind();
                ddlSexo.SelectedValue = gvDoctores.DataKeys[e.NewEditIndex].Values["Id_Sexo_Doctor"].ToString();

                RadioButtonList rbinter = (RadioButtonList)gvDoctores.Rows[e.NewEditIndex].FindControl("rbInterEIT");
                rbinter.DataSource = _intervenciones;
                rbinter.DataTextField = "Nombre_Intervencion";
                rbinter.DataValueField = "Id_Intervencion";
                rbinter.DataBind();
                rbinter.DataSource = gvDoctores.DataKeys[e.NewEditIndex].Values["Id_Intervencion_Doctor"].ToString();

                CheckBoxList chkTurno = (CheckBoxList)gvDoctores.Rows[e.NewEditIndex].FindControl("chkTurnoEIT");
                chkTurno.DataSource = _turnos;
                chkTurno.DataTextField = "Nombre_Turno";
                chkTurno.DataValueField = "Id_Turno";
                chkTurno.DataBind();
                chkTurno.DataSource = gvDoctores.DataKeys[e.NewEditIndex].Values["Id_Turno_Doctor"].ToString();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }


        protected void gvDoctores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvDoctores.DataKeys[e.RowIndex].Values["Id_Doctor"]);
                DeleteDoctor(id);
                Response.Redirect(Request.CurrentExecutionFilePath);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }

        protected void gvDoctores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDoctores.EditIndex = -1;
            LlenargvDoctores();
            LlenarchkTurno();
            LlenarrbIntervencion();
            LlenarddlSexo();
        }

        protected void gvDoctores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                EntDoctor ent = new EntDoctor();
                ent.Id_Doctor = Convert.ToInt32(gvDoctores.DataKeys[e.RowIndex].Values["Id_Doctor"]);
                ent.Nombre_Doctor = ((TextBox)gvDoctores.Rows[e.RowIndex].FindControl("txtNombreEIT")).Text;
                ent.Paterno_Doctor = ((TextBox)gvDoctores.Rows[e.RowIndex].FindControl("txtPaternoEIT")).Text;
                ent.Materno_Doctor = ((TextBox)gvDoctores.Rows[e.RowIndex].FindControl("txtMaternoEIT")).Text;
                ent.Fecha_Naci_Doctor =
                    Convert.ToDateTime(((TextBox)gvDoctores.Rows[e.RowIndex].FindControl("txtFechaEIT")).Text);
                ent.Id_Sexo_Doctor =
                    Convert.ToInt32(((DropDownList)gvDoctores.Rows[e.RowIndex].FindControl("ddlSexoEIT"))
                        .SelectedValue);
                ent.Id_Intervencion_Doctor =
                    Convert.ToInt32(((RadioButtonList)gvDoctores.Rows[e.RowIndex].FindControl("rbInterEIT"))
                        .SelectedValue);
                ent.Id_Turno_Doctor =
                    Convert.ToInt32(
                        ((CheckBoxList)gvDoctores.Rows[e.RowIndex].FindControl("chkTurnoEIT")).SelectedValue);
                ent.Telefono_Doctor = ((TextBox)gvDoctores.Rows[e.RowIndex].FindControl("txtTeleEIT")).Text;
                UpdateDoctor(ent);
                Response.Redirect(Request.CurrentExecutionFilePath);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }

        #endregion gvDoctores

        private void MostrarMensaje(string p)
        {
            string alerta = string.Format("alert('{0}')", p.Replace("'", "").Replace("\r", "").Replace("\n", ""));
            ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EntDoctor ent = new EntDoctor();
                ent.Nombre_Doctor = ((TextBox)gvDoctores.FooterRow.FindControl("txtNombreFT")).Text;
                ent.Paterno_Doctor = ((TextBox)gvDoctores.FooterRow.FindControl("txtPaternoFT")).Text;
                ent.Materno_Doctor = ((TextBox)gvDoctores.FooterRow.FindControl("txtMaternoFT")).Text;
                ent.Fecha_Naci_Doctor =
                    Convert.ToDateTime(((TextBox)gvDoctores.FooterRow.FindControl("txtFechaFT")).Text);
                ent.Id_Sexo_Doctor =
                    Convert.ToInt32(((DropDownList)gvDoctores.FooterRow.FindControl("ddlSexoFT")).SelectedValue);
                ent.Id_Intervencion_Doctor =
                    Convert.ToInt32(((RadioButtonList)gvDoctores.FooterRow.FindControl("rbInterFT")).SelectedValue);
                ent.Id_Turno_Doctor =
                    Convert.ToInt32(((CheckBoxList)gvDoctores.FooterRow.FindControl("chkTurnoFT")).SelectedValue);
                ent.Telefono_Doctor = ((TextBox)gvDoctores.FooterRow.FindControl("txtTeleFT")).Text;

                AddDoctor(ent.Id_Doctor, ent.Nombre_Doctor, ent.Paterno_Doctor, ent.Materno_Doctor,
                    ent.Fecha_Naci_Doctor, ent.Id_Sexo_Doctor, ent.Id_Intervencion_Doctor, ent.Id_Turno_Doctor,
                    ent.Telefono_Doctor);
                Response.Redirect(Request.CurrentExecutionFilePath);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }

        protected void gvDoctores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDoctores.SelectedIndex = -1;
            gvDoctores.PageIndex = e.NewPageIndex;
            LlenargvDoctores();
        }

        protected void gvDoctores_Sorting(object sender, GridViewSortEventArgs e)
        {
            string columna = e.SortExpression;
            string direccion = "";
            if (ViewState["orden"] == null)
            {
                direccion = "asc";
                ViewState["orden"] = "desc";
            }
            else
            {
                direccion = ViewState["orden"].ToString();
                if (direccion == "asc")
                    ViewState["orden"] = "desc";
                else
                    ViewState["orden"] = "asc";
            }

            gvDoctores.DataSource = SortDoctor(columna, direccion);
            gvDoctores.DataBind();
        }

        public List<EntDoctor> GetDoctors()
        {
            return _doctors;
        }

        public void AddDoctor(int id, string nombre, string paterno, string materno, DateTime fechaNacimiento,
            int idSexo, int idIntervencion, int idTurno, string telefono)
        {
            EntDoctor doctor = new EntDoctor
            {
                Id_Doctor = id,
                Nombre_Doctor = nombre,
                Paterno_Doctor = paterno,
                Materno_Doctor = materno,
                Fecha_Naci_Doctor = fechaNacimiento,
                Id_Sexo_Doctor = idSexo,
                Id_Intervencion_Doctor = idIntervencion,
                Id_Turno_Doctor = idTurno,
                Telefono_Doctor = telefono
            };

            _doctors.Add(doctor);
        }

        public void UpdateDoctor(EntDoctor updatedDoctor)
        {
            var doctor = _doctors.FirstOrDefault(d => d.Id_Doctor == updatedDoctor.Id_Doctor);
            if (doctor != null)
            {
                doctor.Nombre_Doctor = updatedDoctor.Nombre_Doctor;
                doctor.Paterno_Doctor = updatedDoctor.Paterno_Doctor;
                doctor.Materno_Doctor = updatedDoctor.Materno_Doctor;
                doctor.Fecha_Naci_Doctor = updatedDoctor.Fecha_Naci_Doctor;
                doctor.Id_Sexo_Doctor = updatedDoctor.Id_Sexo_Doctor;
                doctor.Id_Intervencion_Doctor = updatedDoctor.Id_Intervencion_Doctor;
                doctor.Id_Turno_Doctor = updatedDoctor.Id_Turno_Doctor;
                doctor.Telefono_Doctor = updatedDoctor.Telefono_Doctor;
            }
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _doctors.FirstOrDefault(d => d.Id_Doctor == id);
            if (doctor != null)
            {
                _doctors.Remove(doctor);
            }
        }

        public List<EntDoctor> SortDoctor(string columna, string direccion)
        {
            switch (columna)
            {
                case "Id_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Id_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Id_Doctor).ToList();
                case "Nombre_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Nombre_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Nombre_Doctor).ToList();
                case "Paterno_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Paterno_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Paterno_Doctor).ToList();
                case "Materno_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Materno_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Materno_Doctor).ToList();
                case "Fecha_Naci_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Fecha_Naci_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Fecha_Naci_Doctor).ToList();
                case "Id_Sexo_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Id_Sexo_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Id_Sexo_Doctor).ToList();
                case "Id_Intervencion_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Id_Intervencion_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Id_Intervencion_Doctor).ToList();
                case "Id_Turno_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Id_Turno_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Id_Turno_Doctor).ToList();
                case "Telefono_Doctor":
                    return direccion == "asc"
                        ? _doctors.OrderBy(d => d.Telefono_Doctor).ToList()
                        : _doctors.OrderByDescending(d => d.Telefono_Doctor).ToList();
                default:
                    return _doctors;
            }
        }

        public void GenerateFakeDoctors(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                EntDoctor doctor = new EntDoctor();

                doctor.Id_Doctor = i;
                doctor.Nombre_Doctor = $"Doctor {Guid.NewGuid()}";
                doctor.Paterno_Doctor = $"Paterno {Guid.NewGuid()}";
                doctor.Materno_Doctor = $"Materno {Guid.NewGuid()}";
                doctor.Fecha_Naci_Doctor = DateTime.Now;
                doctor.Id_Sexo_Doctor = i % 2 == 0 ? 1 : 2; // alternating between 1 and 2 for gender
                doctor.Id_Intervencion_Doctor = i; // just an example, replace with actual logic
                doctor.Id_Turno_Doctor = i % 3 + 1; // alternating between 1, 2, and 3 for shift
                doctor.Telefono_Doctor = $"555-01{i:D2}"; // fake phone number
                doctor.Sexo = _sexos.FirstOrDefault(s => s.Id_Sexo == i % 3 + 1);
                doctor.Intervencion = _intervenciones.FirstOrDefault(s => s.Id_Intervencion == i + 1);
                doctor.Turno = _turnos.FirstOrDefault(s => s.Id_Turno == i % 3 + 1);

                _doctors.Add(doctor);
            }
        }
    }

    public class EntDoctor
    {
        public int Id_Doctor { get; set; }
        public string Nombre_Doctor { get; set; }
        public string Paterno_Doctor { get; set; }
        public string Materno_Doctor { get; set; }
        public DateTime Fecha_Naci_Doctor { get; set; }
        public int Id_Sexo_Doctor { get; set; }
        public int Id_Intervencion_Doctor { get; set; }
        public int Id_Turno_Doctor { get; set; }
        public string Telefono_Doctor { get; set; }
        public EntSexo Sexo { get; set; } = new EntSexo();
        public EntIntervencion Intervencion { get; set; } = new EntIntervencion();
        public EntTurno Turno { get; set; } = new EntTurno();
    }

    public class EntSexo
    {
        public int Id_Sexo { get; set; }
        public string Nombre_Sexo { get; set; }
    }

    public class EntIntervencion
    {
        public int Id_Intervencion { get; set; }
        public string Nombre_Intervencion { get; set; }
    }

    public class EntTurno
    {
        public int Id_Turno { get; set; }
        public string Nombre_Turno { get; set; }
    }
}