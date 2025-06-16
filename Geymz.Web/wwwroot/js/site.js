// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var audioContext = new (window.AudioContext || window.webkitAudioContext)();
function PingPage(freq, initTime, decay) {
    var oscillator = audioContext.createOscillator();
    var gainNode = audioContext.createGain();

    oscillator.connect(gainNode);
    gainNode.connect(audioContext.destination);

    oscillator.type = 'sine'; // Or 'triangle', 'square', 'sawtooth'
    oscillator.frequency.setValueAtTime(freq, audioContext.currentTime); // Frequency in Hz

    // Create a quick decay for a "ping" effect
    gainNode.gain.setValueAtTime(initTime, audioContext.currentTime); // Initial volume
    gainNode.gain.exponentialRampToValueAtTime(0.001, audioContext.currentTime + decay);

    oscillator.start(audioContext.currentTime);
    oscillator.stop(audioContext.currentTime + decay); // Stop after the decay
}
function pingViaAudio(freq) {
    PingPage(freq, 0.5, 0.3);
}
