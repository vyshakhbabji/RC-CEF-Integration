function getUserMedia(constraints){
    return navigator.mediaDevices.getUserMedia(constraints);
}

function enumerateDevices(){
    return navigator.mediaDevices.enumerateDevices();
}

function mediaDevices (){
    return navigator.mediaDevices;
}

export class browserAPIManager {
    static enumerateDevices() {
        return enumerateDevices()
    }
    static getUserMedia(arg){
        return getUserMedia(arg);
    }
    
}

