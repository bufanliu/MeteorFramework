require "3rd/pblua/login_pb"
require "3rd/pbc/protobuf"

local lpeg = require "lpeg"

local json = require "cjson"
local util = require "3rd/cjson/util"


require "Logic/LuaClass"
require "Logic/CtrlManager"
require "Common/functions"
require "Common/define"

--管理器--
StartGame = {};
local this = StartGame;

local game; 
local transform;
local gameObject;
local WWW = UnityEngine.WWW;



--初始化完成，发送链接服务器信息--
function StartGame.OnInitOK()
    logWarn('StartGame 11111 InitOK--->>>');
end


--销毁--
function StartGame.OnDestroy()
	--logWarn('OnDestroy--->>>');
end
