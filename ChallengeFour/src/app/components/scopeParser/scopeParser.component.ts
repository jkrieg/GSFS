import { Component, OnInit } from "@angular/core";

@Component({
    selector: "gs-scope-parser",
    templateUrl: "scopeParser.component.html",
    styleUrls:["scopeParser.component.scss"]
})
export class ScopeParserComponent implements OnInit{
    text: string;
    stateMessage: string;
    ngOnInit(){
        this.text = "";
        this.stateMessage = null;
    }
    onParse(){
        if(this.text.length === 0){
            this.stateMessage = null;
            return;
        }
        this.stateMessage = this.isEverythingClosed()? "Everything's closed": "I feel a draft...Make sure everything's closed.";
    }
    //Intentionally ignoring non scoping tokens.
    isEverythingClosed(){
        
        const {text} = this;
        const stack = [];
        const pushers = {"{":"}", "[":"]", "(":")"};
        const poppers = {"}":"{", "]":"[", ")":"("};
        [...text].forEach(c => {
            if(pushers[c]){
                stack.push(c);
                return;
            }
            if(poppers[c]){
                if(poppers[c] === stack[stack.length-1]){
                    stack.splice(stack.length-1, 1);
                    return;
                }
                stack.push(c);
            }
        });
        return stack.length === 0;
    }
}