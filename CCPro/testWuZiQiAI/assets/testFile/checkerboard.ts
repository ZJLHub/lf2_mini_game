// Learn TypeScript:
//  - https://docs.cocos.com/creator/manual/en/scripting/typescript.html
// Learn Attribute:
//  - https://docs.cocos.com/creator/manual/en/scripting/reference/attributes.html
// Learn life-cycle callbacks:
//  - https://docs.cocos.com/creator/manual/en/scripting/life-cycle-callbacks.html

const {ccclass, property} = cc._decorator;
// export default type 
@ccclass
export default class checkerboard extends cc.Component {
    //黑方 1
    //白方 2
    private _allPoint:number[][] = [];


    start () {

    }

    /**下子 
     * @row 行
     * @clound 列
     * @how 白方2 黑方1
    */
    public downPoint(row:number,clound:number,how:number){
        if(!this._allPoint[row]){
            this._allPoint[row] = [];
            for(let i=0;i<10;i++){
                this._allPoint[row].push(0);
            }
        }

        if(this._allPoint[row][clound]){
            console.error("改地方已经有棋子");
        }
        this._allPoint[row][clound] = how;
        
    }
    
    /**创建棋子 */
    private _createPoint(row:number,clound:number,how:number){//TODO

    }

    

}
