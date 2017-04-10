using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace music
{
    public class BLL_UserManage
    {
        //用户登陆
        public bool Login(Model_User user)
        { 
            DAL_UserManage userMgr = new DAL_UserManage();
            return userMgr.login(user);
        }
        //用户注册
        public bool Signup(Model_User user)
        {
            DAL_UserManage userMgr = new DAL_UserManage();
            return userMgr.SignUp(user);
        }
        //用户获取收藏列表
        public DataTable GetCollections(Model_User user)
        { 
            return DAL_UserManage.GetCollections(user);
        }
        //用户删除收藏
        public bool DeleteCollections(int id)
        {
            return DAL_UserManage.DeleteCollections(id);
        }
        //用户修改密码
        public bool userChangePassword(Model_User user)
        {
            DAL_UserManage userMgr = new DAL_UserManage();
            return userMgr.userChangePassword(user);
        }

        /// <summary>
        /// 匹配结果，并转换成JSON字符串
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public string GetMatches(string keyword)
        {
            DAL_UserManage UserMgr = new DAL_UserManage();
            //DataTable dt_temp = UserMgr.GetMatch(keyword);
            DataTable dt_song = UserMgr.GetMatchForSongName(keyword);
            DataTable dt_singer = UserMgr.GetMatchForSingerName(keyword);

            string JSONString = string.Empty;
            JSONString += "{\"res\":[";
            //for (int i = 0; i < dt_temp.Rows.Count; i++)
            //{
            //    JSONString += "\"";
            //    JSONString += dt_temp.Rows[i][0];
            //    JSONString += "————";
            //    JSONString += dt_temp.Rows[i][1];
            //    JSONString += "\",";
            //}
            
            for (int i = 0; i < dt_singer.Rows.Count; i++)
            {
                JSONString += "\"[歌手]";
                JSONString += dt_singer.Rows[i][0];
                JSONString += "\",";
            }
            
            for (int i = 0; i < dt_song.Rows.Count; i++)
            {
                JSONString += "\"[歌曲]";
                JSONString += dt_song.Rows[i][0];
                JSONString += "\",";
            }
            JSONString = JSONString.TrimEnd(',');
            JSONString += "]}";

            return JSONString;
        }

        /// <summary>
        /// 判断歌曲是否存在
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public bool isSongExist(string keyword)
        {
            DAL_UserManage UserMgr = new DAL_UserManage();
            DataTable dt_temp = UserMgr.isSongExist(keyword);
            if (dt_temp.Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }

        //判断歌手是否存在
        public bool isSingerExist(string keyword)
        {
            DAL_UserManage UserMgr = new DAL_UserManage();
            DataTable dt_temp = UserMgr.isSingerEExist(keyword);
            if (dt_temp.Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }

        //判断歌曲是否已经收藏
        public bool isSongCollect(Guid songID ,int userID)
        {
            DAL_UserManage UserMgr = new DAL_UserManage();
            DataTable dt_temp = UserMgr.isSongCollect(songID,userID);
            if (dt_temp.Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }

        //用户添加收藏
        public bool userAddCollection(Model_User user, Model_Song song)
        {
            DAL_UserManage UserMgr = new DAL_UserManage();
            return UserMgr.addCollections(user, song);
        }
        
        //歌曲热度添加
        //添加之前判断是否存在
        public bool addSongHits(Model_Song song)
        {
            string songname = song.SongName;
            bool ret = isSongExist(songname);
            if (ret == true)
            {
                DAL_UserManage UserMgr =new DAL_UserManage();
                return UserMgr.songAddHits(song);
            }
            else
            { return false; }
        }
        //歌手热度添加
        //添加之前判断是否存在
        public bool addSingerHits(Model_Singer singer)
        {
            string singername = singer.SingerName;
            bool ret = isSingerExist(singername);
            if (ret == true)
            {
                DAL_UserManage UserMgr = new DAL_UserManage();
                return UserMgr.singerAddHits(singer);
            }
            else
            { return false; }
        }
    }
}