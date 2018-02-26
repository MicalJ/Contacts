
export class Person {
    constructor();
    constructor(
        public personId?: number,
        public firstName?: string,
        public lastName?: string,
        public phoneNumber?: string,
        public type?: string,
        public email?: string,
        public categoryPersonId?: number
    ) { }
}