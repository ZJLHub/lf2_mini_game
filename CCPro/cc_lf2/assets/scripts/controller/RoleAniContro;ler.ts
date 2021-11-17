// Learn TypeScript:
//  - https://docs.cocos.com/creator/manual/en/scripting/typescript.html
// Learn Attribute:
//  - https://docs.cocos.com/creator/manual/en/scripting/reference/attributes.html
// Learn life-cycle callbacks:
//  - https://docs.cocos.com/creator/manual/en/scripting/life-cycle-callbacks.html

import { RoleState } from "../const/GameConst";

const {ccclass, property} = cc._decorator;

@ccclass
export default class RoleAniController extends cc.Component {
    private _state:RoleState;
    private _ani:cc.Animation;
    onLoad(){
        let ani_node = this.node.getChildByName("ani_node");
        this._ani = ani_node.getComponent(cc.Animation);
    }
    start(){
        this.setState(RoleState.idle);
    }
    public setState(state:RoleState){
        
        this._ani.play(state);
    }

}
