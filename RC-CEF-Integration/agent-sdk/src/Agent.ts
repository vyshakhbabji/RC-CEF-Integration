import {peerConnectionManager, peerConnection} from "./peerConnectionManager";
import {AudioElementManager} from "./audioElementManager"
import {browserAPIManager} from "./browserAPIManager";
import {vmManager} from "./vmManager";

export function getUserMedia (arg){
    return browserAPIManager.getUserMedia(arg);
}

export function enumerateDevices() {
    return browserAPIManager.enumerateDevices();
}

export function agentPeerConnection() {
    return new peerConnection();
}

function close() {
    /*
    *
    * close and cleanup Agent instance
    *
    * */
}
