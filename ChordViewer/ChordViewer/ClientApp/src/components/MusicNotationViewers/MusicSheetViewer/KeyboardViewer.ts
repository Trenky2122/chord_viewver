import {IMusicNotationViewer} from "../IMusicNotationViewer";
import {Utils} from "../../../utils/Utils";
import ContextMenu from "./ContextMenu/ContextMenu";

export class KeyboardViewer implements IMusicNotationViewer{
    RepresentativeElement: HTMLCanvasElement;
    positionToNote = ["C", "D", "E", "F", "G", "A", "B", "C", "D", "E", "F", "G", "A", "B", "C"]
    constructor(private canvasId: string, private contextMenu: ContextMenu) {
        this.RepresentativeElement = document.getElementById(this.canvasId) as HTMLCanvasElement;
        this.RepresentativeElement.addEventListener('contextmenu', this.handleRightClick.bind(this), false);
    }

    private currentNotes: string[] = [];
    private lastClickedNote: string = "";

    View(toneKey: string): boolean {
        if(!this.RepresentativeElement)
            return false;
        this.currentNotes = Utils.GetNotesFromToneKey(toneKey);
        let ctx = this.RepresentativeElement.getContext("2d");
        let width = this.RepresentativeElement.offsetWidth;
        let height = this.RepresentativeElement.offsetHeight;
        ctx!.strokeStyle = "#000001";
        ctx!.fillStyle = "#000000";
        ctx!.clearRect(0, 0, width, height)
        for(let i=0; i<=14; i++) {
            ctx!.fillStyle = "#FFFFF" + this.positionToLastColorLetter(i);
            if (this.currentNotes.indexOf(this.positionToNote[i]) !== -1) {
                ctx!.fillStyle = "#00ff4" + this.positionToLastColorLetter(i);
            }
            ctx!.fillRect(i * width / 15, 0, width / 15, height);
        }
        for(let i=15; i>=0; i--){
            ctx!.beginPath();
            ctx!.moveTo(i*width/15, 0)
            ctx!.lineTo(i*width/15, height)
            ctx!.stroke();
            if(i!==2 && i!==6 && i!==9 && i!==13 && i!==14 && i!==15){
                ctx!.fillStyle = "#00000" + this.positionToLastColorLetter(i);
                if(this.currentNotes.indexOf(this.positionToNote[i]+"#") !== -1){
                    ctx!.fillStyle = "#FF003" + this.positionToLastColorLetter(i);
                }
                ctx!.fillRect(i*width/15 + 3*width/60, 0, width/30, 3*height/5)
            }
        }

        ctx!.beginPath();
        ctx!.moveTo(0, 0)
        ctx!.lineTo(width, 0)
        ctx!.stroke();
        ctx!.beginPath();
        ctx!.moveTo(width, height)
        ctx!.lineTo(0, height)
        ctx!.stroke();

        return true;
    }

    handleRightClick(e: MouseEvent){
        e.preventDefault();
        this.contextMenu.view(e.pageX, e.pageY, this.canvasId, true, true,
            false, false, false)
        let ctx = this.RepresentativeElement!.getContext("2d");
        let clickedPixel = ctx!.getImageData(e.offsetX, e.offsetY, 1, 1,).data;
        let pixelCodedNote = clickedPixel[2] % 16;
        if(pixelCodedNote === 1)
            return;
        let note = ["G", "", "", "", "", "", "", "", "", "", "A", "B", "C", "D", "E", "F"][pixelCodedNote];
        if(clickedPixel[1] === 0)
            note += "#";
        console.log(note);
    }

    positionToLastColorLetter(pos: number){
        let letter = this.positionToNote[pos];
        if(letter.toLowerCase() === "g")
            return "0";
        return letter;
    }

    getActualToneKey(): string {
        return this.currentNotes.sort().join("");
    }

}