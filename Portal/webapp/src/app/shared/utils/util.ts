export class Util {
    static API_URL: string = 'https://localhost:5001';
    static CLIENT_API: string = '/api/Client';
    static FILE_API: string = '/api/Client/file';
    static FILES_API: string = '/api/Client/files';
    static SUBSCRIPTION_API: string = '/api/Client/subscription';
}

export enum CloudProvider {
    Azure = 1,
    Dropbox = 2
}