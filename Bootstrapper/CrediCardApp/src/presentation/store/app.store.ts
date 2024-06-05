import { atom } from "recoil";

import { AtomEffect } from 'recoil';

const localStorageEffect = (key: string): AtomEffect<any> => ({ setSelf, onSet }) => {
    const savedValue = localStorage.getItem(key);
    if (savedValue != null) {
        setSelf(JSON.parse(savedValue));
    }

    onSet((newValue, _, isReset) => {
        isReset
            ? localStorage.removeItem(key)
            : localStorage.setItem(key, JSON.stringify(newValue));
    });
};

export interface AuthUser{
    id: string;
    name: string;
}

export const authStore = atom<AuthUser | null>({
    key: 'stateAuthUser',
    default: null,
    effects_UNSTABLE: [localStorageEffect('stateAuthUser')],
});