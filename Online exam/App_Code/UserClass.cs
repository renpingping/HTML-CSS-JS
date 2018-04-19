using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// UserClass 的摘要说明
/// </summary>
public class UserClass
{
    DBClass dbObj = new DBClass();
	public UserClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************登录界面************************************************************
    /// <summary>
    /// 三个用户登录方法
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPwd">用户密码</param>
    /// <returns>返回数据源中的数据表</returns>
    public DataTable ManagerLogin(string strName, string strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandStr("select * from Manager where Ad_name=@UserName and Ad_password=@Password;");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(密码)
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "Manager");
        return dsTable;
    }
    public DataTable TeacherLogin(string strName, string strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandStr("select * from Teacher where Tc_name=@UserName and Tc_password=@Password;");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(密码)
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "Teacher");
        return dsTable;
    }
    public DataTable StudentLogin(string strName, string strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandStr("select * from Student where St_name=@UserName and St_pwd=@Password;");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(密码)
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "Student");
        return dsTable;
    }
    //***************************************注册界面************************************************************
    /// <summary>
    /// 向用户表中插入信息
    /// </summary>
    /// <param name="strName">会员名</param>
    /// <param name="strPassword">密码</param>
    /// <param name="strRealName">真实姓名</param>
    /// <param name="blSex">性别</param>
    /// <param name="strPhonecode">电话号码</param>
    /// <param name="strEmail">E_Mail</param>
    /// <param name="strAddress">会员详细地址</param>
    /// <param name="strPostCode">邮编</param>
    /// <returns>返回用户ID代号</returns>
    public int AddUser(string strName, string strPassword,bool blSex, string strquestion, string stranswer, string strcardNo, string strphone,string stremail,string strclassId)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_adduser");        
        
        //添加参数
        SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar, 20);
        name.Value = strName;
        myCmd.Parameters.Add(name);

        //添加参数
        SqlParameter password = new SqlParameter("@Password", SqlDbType.VarChar, 20);
        password.Value = strPassword;
        myCmd.Parameters.Add(password);

        //添加参数
        SqlParameter sex = new SqlParameter("@Sex", SqlDbType.Bit, 1);
        sex.Value = blSex;
        myCmd.Parameters.Add(sex);

        //添加参数
        SqlParameter question = new SqlParameter("@question", SqlDbType.VarChar, 50);
        question.Value = strquestion;
        myCmd.Parameters.Add(question);

        //添加参数
        SqlParameter answer = new SqlParameter("@answer", SqlDbType.VarChar, 50);
        answer.Value = stranswer;
        myCmd.Parameters.Add(answer);

        
        //添加参数
        SqlParameter cardNo = new SqlParameter("@cardNo", SqlDbType.VarChar, 18);
        cardNo.Value = strcardNo;
        myCmd.Parameters.Add(cardNo);
        
        //添加参数
        SqlParameter phone = new SqlParameter("@phone", SqlDbType.VarChar, 11);
        phone.Value = strphone;
        myCmd.Parameters.Add(phone);

        //添加参数
        SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar, 30);
        email.Value = stremail;
        myCmd.Parameters.Add(email);

        //添加参数
        SqlParameter classid = new SqlParameter("@classid", SqlDbType.BigInt);
        classid.Value = strclassId;
        myCmd.Parameters.Add(classid);

        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }

    //***************************************修改界面************************************************************
    /// <summary>
    /// 通过用户ID，获取用户的详细信息
    /// </summary>
    /// <param name="IntMemberID">用户ID代号</param>
    /// <returns>返回数据集的表的集合</returns>
    public DataTable GetUserInfo(int IntMemberID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetUI");
        //添加参数
        SqlParameter memberId = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        memberId.Value = IntMemberID;
        myCmd.Parameters.Add(memberId);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }
    /// <summary>
    /// 修改用户表的信息
    /// </summary>
    /// <param name="strName">会员名</param>
    /// <param name="strPassword">密码</param>
    /// <param name="strRealName">真实姓名</param>
    /// <param name="blSex">性别</param>
    /// <param name="strPhonecode">电话号码</param>
    /// <param name="strEmail">E_Mail</param>
    /// <param name="strAddress">会员详细地址</param>
    /// <param name="strPostCode">邮编</param>
    /// <param name="IntMemberID">用户的ID代号</param>
    public void MedifyUser(string strName, string strPassword, string strRealName, bool blSex, string strPhonecode, string strEmail, string strAddress, string strPostCode, int IntMemberID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_ModifyUser");
        //添加参数
        SqlParameter name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);
        //添加参数
        SqlParameter password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        password.Value = strPassword;
        myCmd.Parameters.Add(password);
        //添加参数
        SqlParameter realName = new SqlParameter("@RealName", SqlDbType.VarChar, 50);
        realName.Value = strRealName;
        myCmd.Parameters.Add(realName);
        //添加参数
        SqlParameter sex = new SqlParameter("@Sex", SqlDbType.Bit, 1);
        sex.Value = blSex;
        myCmd.Parameters.Add(sex);
        //添加参数
        SqlParameter phonecode = new SqlParameter("@Phonecode", SqlDbType.VarChar, 20);
        phonecode.Value = strPhonecode;
        myCmd.Parameters.Add(phonecode);
        //添加参数
        SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
        email.Value = strEmail;
        myCmd.Parameters.Add(email);
        //添加参数
        SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        address.Value = strAddress;
        myCmd.Parameters.Add(address);
        //添加参数
        SqlParameter postCode = new SqlParameter("@PostCode", SqlDbType.Char, 10);
        postCode.Value = strPostCode;
        myCmd.Parameters.Add(postCode);
        //添加参数
        SqlParameter memberId = new SqlParameter("@MemberId", SqlDbType.Int, 4);
        memberId.Value = IntMemberID;
        myCmd.Parameters.Add(memberId);
        dbObj.ExecNonQuery(myCmd);
    }

}