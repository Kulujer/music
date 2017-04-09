using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace music
{
    public class BLL_AdminManage
    {
        //用户管理
        public DataTable GetUsers()
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.GetUsers();
        }

        public bool DeleteUser(int id)
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.DeleteUser(id);
        }

        public bool UpdateUser(Model_User user)
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.UpdateUser(user);
        }
        //歌曲管理
        public DataTable GetSongs()
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.GetSongs();
        }
        public bool EditSong(Model_Song song)
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.editSong(song);
        }
        //歌手管理
        public DataTable GetSingers()
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.GetSingers();
        }
        public bool EditSinger(Model_Singer singer)
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.editSinger(singer);
        }
        //爬虫管理
        public DataTable GetGrap()
        {
            DAL_AdminManage AdminMgr = new DAL_AdminManage();
            return AdminMgr.GetGrap();
        }
    }
}