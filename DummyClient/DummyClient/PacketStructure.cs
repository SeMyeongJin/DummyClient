using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace DummyClient
{
    class PacketStructure
    {
    }
}

public class GValue
{
    public static int packetNumber = 1;
}

public enum TCP_PROTOCOL
{
    PT_VERSION = 0x1000000,
    PT_REQ_USER_INFO,
    PT_RES_USER_INFO,
    PT_OFFICIAL_GAME_START,
    PT_OFFICIAL_GAME_START_SUCC,
    PT_OFFICIAL_GAME_START_FAIL,
    PT_FRIENDSHIP_GAME_START,
    PT_FRIENDSHIP_GAME_START_SUCC,
    PT_FRIENDSHIP_GAME_START_FAIL,
    PT_ROOM_LEAVE,
    PT_ROOM_LEAVE_SUCC,
    PT_ROOM_LEAVE_FAIL,
    PT_GAME_START_ALL,
    PT_GAME_END_ALL,
    PT_CHAT,
    PT_DELIVERY_CHAT,
    PT_PIECE_MOVE,
    PT_PIECE_PROMOTION,
    PT_OFFICIAL_GAME_WIN,
    PT_OFFICIAL_GAME_LOSE,
    PT_FRIENDSHIP_GAME_WIN,
    PT_RESIGNS,
    PT_DELIVERY_RESIGNS,
    PT_END
};

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
public class GamePacketHeader
{
    public int PackSize;
    public int PackNum;
    public TCP_PROTOCOL code;
    public GamePacketHeader() { }

    //헤더
    public GamePacketHeader(int size, int num, TCP_PROTOCOL type)
    {
        PackSize = size;
        PackNum = num;
        code = type;
    }
}

// PT_DELIVERY_CHAT
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public class PT_DELIVERY_CHAT : GamePacketHeader
{
    public PT_DELIVERY_CHAT() { }
    public PT_DELIVERY_CHAT(string message, int packNum)
        : base(Marshal.SizeOf(typeof(PT_DELIVERY_CHAT)), packNum, TCP_PROTOCOL.PT_DELIVERY_CHAT)
    {
        Message = message;
    }
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Message;
}