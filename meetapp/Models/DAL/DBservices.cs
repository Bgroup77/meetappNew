using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using meetapp.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //    //
        //    // TODO: Add constructor logic here
        //    //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {
        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a PreferenceParticipantMeeting to the Preference_Participant_Meeting table 
    //--------------------------------------------------------------------------------------------------
    public int insertPreferenceParticipantMeeting(PreferenceParticipantMeeting ppm)
    {
        SqlConnection con;
        SqlCommand cmd;
        //SqlCommand cmd1;
        //int insertedId;

        try
        {
            con = connect("ConnectionStringMeetapp"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //foreach (var preferenceId in ppm.PreferenceId)
        //{
        //    String cStr = BuildInsertPreferenceParticipantMeetingCommand(ppm, preferenceId);
        //    cmd = CreateCommand(cStr, con);
        //}

        //String cStr = BuildInsertPreferenceParticipantMeetingCommand(ppm);      // helper method to build the insert string
        //cmd = CreateCommand(cStr, con);             // create the command

        try
        {
                // execute the command
                int numEffected = 0;

            foreach (var preferenceId in ppm.PreferenceId)
                {
                String cStr = BuildInsertPreferenceParticipantMeetingCommand(ppm, preferenceId);
                cmd = CreateCommand(cStr, con);
                numEffected = cmd.ExecuteNonQuery();
                }
                // execute the command
                // insertedId = (int)cmd.ExecuteScalar();
                //int numEffected = cmd.ExecuteNonQuery();

            //    foreach (var preferenceId in ppm.PreferenceId)
            //{
            //    String cStr = BuildInsertPreferenceParticipantMeetingCommand(ppm, preferenceId);
            //    cmd = CreateCommand(cStr, con);
            //}

            //int numEffected = cmd.ExecuteNonQuery();
            //foreach (var preference in participant.Preferences)
            //{
            //    String cStr2 = BuildInsertCommandPreferencePerParticipant(insertedId, preference);
            //    cmd1 = CreateCommand(cStr2, con);
            //    numEffected = cmd1.ExecuteNonQuery();
            //}

            return numEffected;

        }

        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert a participant command String
    //--------------------------------------------------------------------

    private String BuildInsertPreferenceParticipantMeetingCommand(PreferenceParticipantMeeting ppm, int preferenceId)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
            sb.AppendFormat("Values({0},{1},{2})", ppm.ParticipantId, preferenceId, ppm.MeetingId);
            String prefix = "INSERT INTO participant_preference_meeting " + "(participantID,preferenceID,meetingID)  ";
            command = prefix + sb.ToString();

            return command;
        //sb.AppendFormat("Values({0},{1},{2})", ppm.ParticipantId,ppm.PreferenceId,ppm.MeetingId);
        //String prefix = "INSERT INTO participant_preference_meeting " + "(participantID,preferenceID,meetingID)  ";
        //command = prefix + sb.ToString();
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a participant to the partiipant table 
    //--------------------------------------------------------------------------------------------------
    public int insert(Participant participant)
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd1;
        int insertedId;

        try
        {
            con = connect("ConnectionStringMeetapp"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(participant);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            // execute the command
            insertedId= (int)cmd.ExecuteScalar();
            int numEffected = 0;

            foreach (var preference in participant.Preferences)
            {
                String cStr2 = BuildInsertCommandPreferencePerParticipant(insertedId, preference);
                cmd1 = CreateCommand(cStr2, con);
                numEffected = cmd1.ExecuteNonQuery();
            }

            return numEffected;

        }

        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert a participant command String
    //--------------------------------------------------------------------

    private String BuildInsertCommand(Participant participant)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}')", participant.Email.ToString(), participant.FirstName.ToString(), participant.LastName.ToString(), participant.Password.ToString(), participant.Phone.ToString(), participant.Gender, participant.Image.ToString(), participant.Address.ToString());
        String prefix = "INSERT INTO participant " + "(email,firstName,lastName,password,phone,gender,image,address)  output INSERTED.ID ";
        command = prefix + sb.ToString();

        return command;
    }
    //--------------------------------------------------------------------------------------------------
    // This method inserts a businessOwner to the businessOwner table 
    //--------------------------------------------------------------------------------------------------
    public int insert(BusinessOwner bo)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("ConnectionStringMeetapp"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(bo);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            // execute the command
            int numEffected = 0;
            numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }

        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert a businessOwner command String
    //--------------------------------------------------------------------

    private String BuildInsertCommand(BusinessOwner bo)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}','{1}','{2}','{3}')", bo.Email.ToString(), bo.FirstName.ToString(), bo.LastName.ToString(), bo.Password.ToString());
        String prefix = "INSERT INTO businessOwner " + "(email,firstName,lastName,password)  ";
        command = prefix + sb.ToString();

        return command;
    }

    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object
        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 
        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds
        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    public bool ValidMail(string conString, string tableName, string email)
    {
        SqlConnection con = null;


        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " WHERE email ='" + email + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            if (dr.Read()) return true;
            else return false;

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    //getting participants list from DB for meeting

    public List<Participant> Read(string conString, string tableName)
    {

        SqlConnection con = null;
        SqlConnection con1 = null;
        List<Participant> lp = new List<Participant>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Participant p = new Participant();
                int participantID = Convert.ToInt32(dr["ID"]);
                p.Email = Convert.ToString(dr["email"]);
               // lp.Add(p);

            con1 = connect(conString);
            String selectSTR1 = "SELECT * FROM participant_preference WHERE participant_preference.participantID=" + participantID;
            SqlCommand cmd1 = new SqlCommand(selectSTR1, con1);

            // get a reader
            SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

            int[] preferencesId = null;
            List<int> li = new List<int>();

            while (dr1.Read())
            {
                li.Add(Convert.ToInt32(dr1["preferenceID"]));
            }
                preferencesId = li.ToArray();
            p.Preferences = preferencesId;
            lp.Add(p);
            }
            return lp;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    //Get participant details (for insert preferences to meeting)
    public Participant GetPreferences(string conString, string tableName, string Email)
    {
        SqlConnection con = null;
        SqlConnection con1 = null;

        Participant p = new Participant();

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " WHERE email ='" + Email + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row

                p.Id = Convert.ToInt32(dr["id"]);
                p.Email = Convert.ToString(dr["email"]);
                //p.FamilyName = Convert.ToString(dr["familyName"]);
                //p.Address = Convert.ToString(dr["address"]);
                //p.Age = Convert.ToSingle(dr["age"]);
                //p.Height = Convert.ToSingle(dr["height"]);
                //p.Gender = Convert.ToString(dr["gender"]);
                //p.Img = Convert.ToString(dr["img"]);
                //p.Phone = Convert.ToString(dr["phoneNum"]);
                //p.IsActive = Convert.ToInt32(dr["isActive"]);
                //p.IsPremium = Convert.ToInt32(dr["isPremium"]);
                //p.Password = Convert.ToString(dr["password"]);
                //p.Mail = Convert.ToString(dr["mail"]);

                con1 = connect(conString);
                String selectSTR1 = "SELECT * FROM participant_preference WHERE participant_preference.participantID=" + p.Id;
                SqlCommand cmd1 = new SqlCommand(selectSTR1, con1);

                // get a reader
                SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

                int[] preferencesId = null;
                List<int> li = new List<int>();

                while (dr1.Read())
                {
                    li.Add(Convert.ToInt32(dr1["preferenceID"]));
                }
                preferencesId = li.ToArray();
                p.Preferences = preferencesId;
            }

            return p;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    //Get meeting details (for show all the meeting of participant)
    public List<Meeting> GetMeetingPerParticipant(string conString, string tableName, string Email)
    {
        SqlConnection con = null;
        //SqlConnection con1 = null;
        List<Meeting> lm = new List<Meeting>();

       //Participant p = new Participant();
        

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM participant WHERE email ='" + Email + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            while (dr.Read())
            {   // Read till the end of the data into a row

               //int userID = Convert.ToInt32(dr["id"]);
                string userEmail = Convert.ToString(dr["email"]);

                con = connect(conString);
                // String selectSTR1 = "SELECT * FROM participant_meeting WHERE participant_meeting.participantID=" + p.Id;
                String selectSTR1 = "select * from participant P join participant_meeting PM on  P.ID= PM.participantID join meeting M on PM.meetingID = M.ID where P.email ='" + userEmail + "'";                           

                SqlCommand cmd1 = new SqlCommand(selectSTR1, con);

                // get a reader
                SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr1.Read())
                {
                    Meeting m = new Meeting();
                    m.Id = Convert.ToInt32(dr1["meetingID"]);
                    m.Subject = Convert.ToString(dr1["subject"]);
                    m.StartHour= Convert.ToString(dr1["startHour"]);
                    m.TimeTillRunningHours= Convert.ToInt32(dr1["timeTillRunningHoures"]);
                    m.SpecificLocation = Convert.ToString(dr1["specificLocation"]);
                    m.Notes= Convert.ToString(dr1["notes"]);
                    m.StatusID = 1;
                    m.CreatorID = 1;
                    m.BusinessID = 1;
                    lm.Add(m);            
                }

            }
            return lm;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    public Meeting GetMeetingById(string conString, string tableName, int meetingId)
    {
        SqlConnection con = null;
        SqlConnection con1 = null;

        Meeting m = new Meeting();

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " WHERE ID =" + meetingId;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row

               m.Id = Convert.ToInt32(dr["id"]);
                m.Subject = Convert.ToString(dr["subject"]);
                m.StartTime = Convert.ToString(dr["startDate"]);
                m.StartHour = Convert.ToString(dr["startHour"]);
                m.TimeTillRunningHours = Convert.ToInt32(dr["timeTillRunningHoures"]);
                m.SpecificLocation = Convert.ToString(dr["specificLocation"]);
                m.Notes = Convert.ToString(dr["notes"]);
               // m.StatusID = Convert.ToInt32(dr["statusID"]);
              // m.CreatorID = Convert.ToInt32(dr["creatorID"]);

                con1 = connect(conString);
                String selectSTR1 = "SELECT * FROM participant_meeting WHERE participant_meeting.meetingID=" + m.Id;
                SqlCommand cmd1 = new SqlCommand(selectSTR1, con1);

                // get a reader
                SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

                int[] participantsId = null;
                List<int> li = new List<int>();

                while (dr1.Read())
                {
                    li.Add(Convert.ToInt32(dr1["participantID"]));
                }
                participantsId = li.ToArray();
                m.Participants = participantsId;
            }
            return m;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {

                con.Close();
            }
        }

    }


    //Get meeting details (for show all the meeting of participant)
    public List<Preference> GetPreferenceParticipantMeeting(string conString, string tableName, int meetingId)
    {
        SqlConnection con = null;
        SqlConnection con1 = null;
        List<Preference> lp = new List<Preference>();

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file
            //int userID = Convert.ToInt32(dr["id"]);
            String selectSTR = "SELECT * FROM participant_preference_meeting WHERE meetingID =" + meetingId ;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            while (dr.Read())
            {   // Read till the end of the data into a row

                int preferenceID = Convert.ToInt32(dr["preferenceID"]);

                con1 = connect(conString);
                // String selectSTR1 = "SELECT * FROM participant_meeting WHERE participant_meeting.participantID=" + p.Id;
                String selectSTR1 = "select * from preference where ID=" + preferenceID;
                SqlCommand cmd1 = new SqlCommand(selectSTR1, con1);
                // get a reader
                SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr1.Read())
                {
                    Preference p = new Preference();
                    p.Id = Convert.ToInt32(dr1["ID"]);
                    p.Name = Convert.ToString(dr1["name"]);
                    p.Type = Convert.ToString(dr1["type"]);                 
                    lp.Add(p);
                }

            }
            return lp;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }


    //--------------------------------------------------------------------
    // Build the Insert hobbies per person command String
    //--------------------------------------------------------------------
    private String BuildInsertCommandPreferencePerParticipant(int participantId, int preferenceId)
    {
        String command;
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0},{1})", participantId, preferenceId);
        String prefix = "INSERT INTO participant_preference" + "(participantID,preferenceID) ";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------------------------------------
    // This method Updates a person in the persons table 
    //--------------------------------------------------------------------------------------------------
    public int PutUpdate(BusinessOwner bo)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("ConnectionStringMeetapp"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildUpdateCommand(bo);    // helper method to build the Update string
        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            // execute the command
            return 0;
        }

        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //--------------------------------------------------------------------
    // Build the Update a person command String
    //--------------------------------------------------------------------
    private String BuildUpdateCommand(BusinessOwner bo)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string

        String prefix = "UPDATE businessOwner SET firstName ='" + bo.FirstName + "', lastName ='" + bo.LastName + "', password = '" + bo.Password + "' output INSERTED.id WHERE email = '" + bo.Email + "' ";
        command = prefix + sb.ToString();

        return command;
    }



    //--------------------------------------------------------------------------------------------------
    // This method Updates a person in the persons table 
    //--------------------------------------------------------------------------------------------------
    public int PutUpdate(Participant participant)
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;

        int insertedId;

        try
        {
            con = connect("ConnectionStringMeetapp"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildUpdateCommand(participant);    // helper method to build the Update string
        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            // execute the command
            insertedId = (int)cmd.ExecuteScalar();
            String cStr1 = BuildDeleteCommand(insertedId);
            cmd1 = CreateCommand(cStr1, con);
            int numEffected = cmd1.ExecuteNonQuery();

            foreach (var preference in participant.Preferences)
            {
                String cStr2 = BuildInsertCommandPreferencePerParticipant(insertedId, preference);
                cmd2 = CreateCommand(cStr2, con);
                numEffected = cmd2.ExecuteNonQuery();
            }

            return numEffected;
        }

        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //public int PutUpdate(Participant participant)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("ConnectionStringMeetapp"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //    var prefix = "";
    //    StringBuilder sb = new StringBuilder();
    //    StringBuilder sbPersonHobbies = new StringBuilder();
    //    //String cStr = $"UPDATE PersonTbl SET Telephone = {p.Telephone} ,Age = {p.Age},Name = '{p.Name}',FamilyName='{p.FamilyName}',Address = '{p.Address}',Password={p.Password},Email='{p.Email}',Gender= '{p.Gender}',Image= '{p.Image}',Height={p.Height} WHERE Id ={p.Id}";
    //    String cStr = "UPDATE participant SET email ='" + participant.Email.ToString() + "', firstName ='" + participant.FirstName.ToString() + "', lastName = '" + participant.LastName.ToString() + "' ,password = '" + participant.Password.ToString() + "' ,phone ='" + participant.Phone.ToString() + "' ,image ='" + participant.Image.ToString() + "', address = '" + participant.Address + "' output INSERTED.id WHERE ID = '" + participant.Id + "' ";
    //    cStr += " DELETE FROM participant_preference WHERE participantID = " + participant.Id;
    //    prefix += " INSERT INTO participant_preference " + " (participantID,preferenceID) ";

    //    for (int i = 0; i < participant.Preferences.Length; i++)
    //    {

    //        sb = new StringBuilder();
    //        sb.AppendFormat("Values({0}, {1})", participant.Id, participant.Preferences[i]);
    //        cStr += prefix + sb.ToString();
    //    }

    //    cmd = CreateCommand(cStr, con);             // create the command

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery(); // execute the command
    //        return numEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}



    //--------------------------------------------------------------------
    // Build the Update a person command String
    //--------------------------------------------------------------------
    private String BuildUpdateCommand(Participant participant)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string

        String prefix = "UPDATE participant SET email ='" + participant.Email.ToString() + "', firstName ='" + participant.FirstName.ToString() + "', lastName = '" + participant.LastName.ToString() + "' ,password = '" + participant.Password.ToString() + "' ,phone ='" + participant.Phone.ToString() + "' ,image ='" + participant.Image.ToString() + "', address = '" + participant.Address  + "' output INSERTED.id WHERE ID = '" + participant.Id + "' ";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // Build the DELETE hobbies a person command String
    //--------------------------------------------------------------------
    private String BuildDeleteCommand(int id)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string

        String prefix = "DELETE from participant_preference WHERE participantID = " + id;
        command = prefix + sb.ToString();

        return command;
    }




    public DBservices ReadFromDataBase(string conString, string tableName)
    {
        SqlConnection con = null;

        try
        {
            con = connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            this.dt = dt;
            this.da = da;

            return this;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    // update the dataset into the database
    //---------------------------------------------------------------------------------
    public void Update()
    {
        // the command build will automatically create insert/update/delete commands according to the select command
        SqlCommandBuilder builder = new SqlCommandBuilder(da);
        da.Update(dt);
    }


    //get people filted by min age, max age and gender
    //public List<Person> Filter(string conString, string tableName, Filter filter)
    //{

    //    SqlConnection con = null;
    //    List<Person> lp = new List<Person>();
    //    try
    //    {
    //        con = connect(conString); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "SELECT * FROM " + tableName + " where age >=" + filter.MinAge + " and age<=" + filter.MaxAge + " and gender='" + filter.Gender + "'";
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

    //        while (dr.Read())
    //        {   // Read till the end of the data into a row
    //            Person p = new Person();

    //            p.Name = Convert.ToString(dr["name"]);
    //            p.FamilyName = Convert.ToString(dr["familyName"]);
    //            p.Address = Convert.ToString(dr["address"]);
    //            p.Age = Convert.ToSingle(dr["age"]);
    //            p.Height = Convert.ToSingle(dr["height"]);
    //            p.Gender = Convert.ToString(dr["gender"]);
    //            p.Img = Convert.ToString(dr["img"]);

    //            lp.Add(p);
    //        }

    //        return lp;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }

    //}

    //get all person fron PersonTbl

    //public List<Person> GetPersonList(string conString, string tableName)
    //{

    //    SqlConnection con = null;
    //    SqlConnection con1 = null;
    //    List<Person> lp = new List<Person>();
    //    try
    //    {
    //        con = connect(conString); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "SELECT * FROM " + tableName;
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

    //        while (dr.Read())
    //        {   // Read till the end of the data into a row
    //            Person p = new Person();

    //            p.Id = Convert.ToInt32(dr["id"]);
    //            p.Name = Convert.ToString(dr["name"]);
    //            p.FamilyName = Convert.ToString(dr["familyName"]);
    //            p.Address = Convert.ToString(dr["address"]);
    //            p.Age = Convert.ToSingle(dr["age"]);
    //            p.Height = Convert.ToSingle(dr["height"]);
    //            p.Gender = Convert.ToString(dr["gender"]);
    //            p.Img = Convert.ToString(dr["img"]);
    //            p.Phone = Convert.ToString(dr["phoneNum"]);
    //            p.IsActive = Convert.ToInt32(dr["isActive"]);
    //            p.IsPremium = Convert.ToInt32(dr["isPremium"]);
    //            p.Password = Convert.ToString(dr["password"]);
    //            p.Mail = Convert.ToString(dr["mail"]);

    //            con1 = connect(conString);
    //            String selectSTR1 = "SELECT * FROM HobbiesPerPerson WHERE HobbiesPerPerson.PersonId=" + p.Id;
    //            SqlCommand cmd1 = new SqlCommand(selectSTR1, con1);

    //            // get a reader
    //            SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

    //            int[] hobbiesId = null;
    //            List<int> li = new List<int>();

    //            while (dr1.Read())
    //            {
    //                li.Add(Convert.ToInt32(dr1["HobbyId"]));
    //            }
    //            hobbiesId = li.ToArray();
    //            p.Hobbies = hobbiesId;
    //            lp.Add(p);
    //        }

    //        return lp;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }

    //}

    //Get a list of preferences from DB
    public List<Preference> ReadPreferences(string conString, string tableName)
    {

        SqlConnection con = null;
        List<Preference> lp = new List<Preference>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Preference p = new Preference();
                p.Id = Convert.ToInt32(dr["ID"]);
                p.Name = Convert.ToString(dr["name"]);
                lp.Add(p);
            }

            return lp;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }


    //Get a list of business from DB
    public List<Business> ReadBusinesses(string conString, string tableName)
    {

        SqlConnection con = null;
        List<Business> lb = new List<Business>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Business b = new Business();
                b.Name = Convert.ToString(dr["name"]);
                lb.Add(b);
            }

            return lb;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    //insert to db meeting's participants 

    public int insertMeeting(Meeting meeting)
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd1;
        int insertedId;

        try
        {
            con = connect("ConnectionStringMeetapp"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(meeting);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            // execute the command
            insertedId = (int)cmd.ExecuteScalar();
            int numEffected = 0;

            foreach (var participant in meeting.Participants)
            {
              String cStr2 = BuildInsertCommandParticipantPerMeeting(participant, insertedId);
                cmd1 = CreateCommand(cStr2, con);
                numEffected = cmd1.ExecuteNonQuery();
            }

            return numEffected;

        }

        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert a meeting command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Meeting meeting)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}','{1}',{2},{3},{4},'{5}','{6}',{7})", meeting.Subject.ToString(), meeting.StartTime.ToString(), meeting.StatusID, meeting.CreatorID, meeting.TimeTillRunningHours, meeting.SpecificLocation.ToString(), meeting.Notes.ToString(),meeting.BusinessID,meeting.Id);
        String prefix = "INSERT INTO meeting " + "(subject,startDate,statusID,creatorID,timeTillRunningHoures,specificLocation,notes,businessID,ID) output INSERTED.ID ";
        command = prefix + sb.ToString();

        return command;
    }



    //--------------------------------------------------------------------
    // Build the Insert hobbies per person command String
    //--------------------------------------------------------------------
    
    //continue!!!
    private String BuildInsertCommandParticipantPerMeeting(int participantId, int meetingId)
    {
        String command;
        StringBuilder sb = new StringBuilder(); 
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0},{1})", participantId, meetingId);
        String prefix = "INSERT INTO participant_meeting" + "(participantID,meetingID) ";
        command = prefix + sb.ToString();

        return command;
    }

    private String BuildinsertPreferencesPerMeetingPerParticipant(int participantId, int meetingId, int preferenceId)
    {
        String command;
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string 
        sb.AppendFormat("Values({0},{1},{2})", participantId, preferenceId, meetingId);
        String prefix = "INSERT INTO participant_preference_meeting" + "(participantID,preferenceID,meetingID) ";
        command = prefix + sb.ToString();

        return command;
    }

    public Participant GetParticipantDetails(string conString, string tableName, string email)
    {
        SqlConnection con = null;
        SqlConnection con1 = null;

        Participant p = new Participant();

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " WHERE email ='" + email + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row

                p.Id = Convert.ToInt32(dr["id"]);
                p.FirstName = Convert.ToString(dr["firstName"]);
                p.LastName = Convert.ToString(dr["lastName"]);
                p.Email = Convert.ToString(dr["email"]);
                p.Password = Convert.ToString(dr["password"]);
                p.Phone = Convert.ToString(dr["phone"]);
                p.Address = Convert.ToString(dr["address"]);
                //p.BirthDate = Convert.ToDateTime(dr["birthdate"]);
                p.Gender = Convert.ToInt32(dr["gender"]);
                p.Image = Convert.ToString(dr["image"]);

                con1 = connect(conString);
                String selectSTR1 = "SELECT * FROM participant_preference WHERE participant_preference.participantID=" + p.Id;
                SqlCommand cmd1 = new SqlCommand(selectSTR1, con1);

                // get a reader
                SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

                int[] preferencesId = null;
                List<int> li = new List<int>();

                while (dr1.Read())
                {
                    li.Add(Convert.ToInt32(dr1["preferenceID"]));
                }
                preferencesId = li.ToArray();
                p.Preferences = preferencesId;
            }
            return p;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {

                con.Close();
            }
        }

    }

    public bool GetParticipant(string conString, string tableName, string email, string password)
    {
        SqlConnection con = null;

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            string selectSTR = "SELECT * FROM " + tableName + " WHERE email ='" + email + "' AND password= '" + password + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            if (dr.Read())
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public bool GetBusinessOwner(string conString, string tableName, string mail, string password)
    {
        SqlConnection con = null;

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            string selectSTR = "SELECT * FROM " + tableName + " WHERE email ='" + mail + "' AND password= '" + password + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            if (dr.Read())
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }

    }

    //Get person details (for update)
    public BusinessOwner GetBoDetails(string conString, string tableName, string Mail)
    {
        SqlConnection con = null;

        BusinessOwner bo = new BusinessOwner();

        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " WHERE email ='" + Mail + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row

                bo.Id = Convert.ToInt32(dr["id"]);
                bo.FirstName = Convert.ToString(dr["firstName"]);
                bo.LastName = Convert.ToString(dr["lastName"]);
                bo.Email = Convert.ToString(dr["email"]);
                bo.Password = Convert.ToString(dr["password"]);
                //bo.Gender = Convert.ToInt32(dr["gender"]);
            }
            return bo;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }




    //Get person details (for update)
    //public Person GetDetails(string conString, string tableName, string Mail)
    //{
    //    SqlConnection con = null;
    //    SqlConnection con1 = null;

    //    Person p = new Person();

    //    try
    //    {
    //        con = connect(conString); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "SELECT * FROM " + tableName + " WHERE mail ='" + Mail + "'";
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

    //        while (dr.Read())
    //        {   // Read till the end of the data into a row

    //            p.Id = Convert.ToInt32(dr["id"]);
    //            p.Name = Convert.ToString(dr["name"]);
    //            p.FamilyName = Convert.ToString(dr["familyName"]);
    //            p.Address = Convert.ToString(dr["address"]);
    //            p.Age = Convert.ToSingle(dr["age"]);
    //            p.Height = Convert.ToSingle(dr["height"]);
    //            p.Gender = Convert.ToString(dr["gender"]);
    //            p.Img = Convert.ToString(dr["img"]);
    //            p.Phone = Convert.ToString(dr["phoneNum"]);
    //            p.IsActive = Convert.ToInt32(dr["isActive"]);
    //            p.IsPremium = Convert.ToInt32(dr["isPremium"]);
    //            p.Password = Convert.ToString(dr["password"]);
    //            p.Mail = Convert.ToString(dr["mail"]);

    //            con1 = connect(conString);
    //            String selectSTR1 = "SELECT * FROM HobbiesPerPerson WHERE HobbiesPerPerson.PersonId=" + p.Id;
    //            SqlCommand cmd1 = new SqlCommand(selectSTR1, con1);

    //            // get a reader
    //            SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);

    //            int[] hobbiesId = null;
    //            List<int> li = new List<int>();

    //            while (dr1.Read())
    //            {
    //                li.Add(Convert.ToInt32(dr1["HobbyId"]));
    //            }
    //            hobbiesId = li.ToArray();
    //            p.Hobbies = hobbiesId;
    //        }

    //        return p;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }

    //}


    //public bool ValidMail(string conString, string tableName, string Mail)
    //{
    //    SqlConnection con = null;


    //    try
    //    {
    //        con = connect(conString); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "SELECT * FROM " + tableName + " WHERE mail ='" + Mail + "'";
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

    //        if (dr.Read()) return true;
    //        else return false;

    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }

    //}

    //public List<Hobbies> Read(string conString, string tableName)
    //{

    //    SqlConnection con = null;
    //    List<Hobbies> lh = new List<Hobbies>();
    //    try
    //    {
    //        con = connect(conString); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "SELECT * FROM " + tableName;
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

    //        while (dr.Read())
    //        {   // Read till the end of the data into a row
    //            Hobbies h = new Hobbies();
    //            h.Id = Convert.ToInt32(dr["Id"]);
    //            h.Name = Convert.ToString(dr["HobbyName"]);
    //            lh.Add(h);
    //        }

    //        return lh;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }

    //}

    ////update active status for a person
    //public int UpdateActive(int Active, int PersonId)
    //{
    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("ConnectionStringTinder"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    String cStr = "UPDATE PersonTbl2 set PersonTbl2.isActive = " + Active + "WHERE PersonTbl2.Id= " + PersonId;
    //    cmd = CreateCommand(cStr, con); // create the command

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery(); // execute the command

    //        return numEffected;

    //    }

    //    catch (Exception ex)
    //    {
    //        return 0;
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}



}